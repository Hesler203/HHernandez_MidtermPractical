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

    void Start()
    {
        playerHealth = FindAnyObjectByType<PlayerHealth>();
        rb = GetComponent<Rigidbody>();

        randomMoveDirection = RandomizeDirection();
        randomSpeed = RandomizeSpeed();
        randomDamage = RandomizeDamage();
    }

    void FixedUpdate()
    {
        rb.AddRelativeForce(randomMoveDirection * randomSpeed, ForceMode.Acceleration);
    }

    private Vector3 RandomizeDirection()
    {
        float randomX = Random.Range(-Random.value, Random.value);
        float randomZ = Random.Range(-Random.value, Random.value);
        return new Vector3(randomX, 0, randomZ).normalized;
    }

    private float RandomizeSpeed()
    {
        return (Random.Range(Random.value, Random.value) * forceMultiplier);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }

        if (other.collider.CompareTag("Player"))
        {
            playerHealth.TakeDamage(randomDamage);

            Destroy(this.gameObject);
        }
    }

    private int RandomizeDamage()
    {
        return Random.Range(MIN_DAMAGE, MAX_DAMAGE + 1);
    }
}
