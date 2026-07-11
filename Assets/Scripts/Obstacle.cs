using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private Rigidbody rb;
    [SerializeField] private float forceMultiplier;
    private const int MIN_DAMAGE = 1;
    private const int MAX_DAMAGE = 5;
    private Vector3 randomMoveDirection;
    private float randomSpeed;
    private int randomDamage;

    /// <summary>
    /// Initializes references & randomized speed, damage, and move direction variables.
    /// </summary>
    void Start()
    {
        playerHealth = FindAnyObjectByType<PlayerHealth>();
        rb = GetComponent<Rigidbody>();

        randomMoveDirection = RandomizeDirection();
        randomSpeed = RandomizeSpeed();
        randomDamage = RandomizeDamage();
    }

    /// <summary>
    /// Applies a constant force to the player in a random direction & with random speed.
    /// </summary>
    void FixedUpdate()
    {
        rb.AddRelativeForce(randomMoveDirection * randomSpeed, ForceMode.Acceleration);
    }

    /// <summary>
    /// Returns a random direction Vector generated with respect to the x & z axis.
    /// </summary>
    /// <returns>Normalized Vector3 direction</returns>
    private Vector3 RandomizeDirection()
    {
        float randomX = Random.Range(-Random.value, Random.value);
        float randomZ = Random.Range(-Random.value, Random.value);
        return new Vector3(randomX, 0, randomZ).normalized;
    }

    /// <summary>
    /// Returns a randomly generated speed magnitude modfified by the forceMultiplier.
    /// </summary>
    /// <returns>Random positive float speed</returns>
    private float RandomizeSpeed()
    {
        return (Random.Range(Random.value, Random.value) * forceMultiplier);
    }

    /// <summary>
    /// Returns a random damage value within the min & max damage range.
    /// </summary>
    /// <returns>int damage</returns>
    private int RandomizeDamage()
    {
        return Random.Range(MIN_DAMAGE, MAX_DAMAGE + 1);
    }

    /// <summary>
    /// Destroys this obstacle when colliding with either the player or the wall.
    /// Deals random damage to the player & decreases the current obstacle count before self-destruct.
    /// </summary>
    /// <param name="other">the object involved in the collision with this obstacle</param>
    void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Wall"))
        {
            FindAnyObjectByType<ObstacleSpawner>().DecreaseObstacleCount();
            Destroy(this.gameObject);
        }

        if (other.collider.CompareTag("Player"))
        {
            playerHealth.TakeDamage(randomDamage);
            FindAnyObjectByType<ObstacleSpawner>().DecreaseObstacleCount();
            Destroy(this.gameObject);
        }
    }
}
