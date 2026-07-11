using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float bobbingSpeed;
    [SerializeField] private float bobbMinHeight;
    [SerializeField] private float bobbMaxHeight;
    private bool directionFlip;
    [SerializeField] private int pointValue;

    /// <summary>
    /// Rotates the coin around its local y-axis at a constant speed
    /// and bobbs up & down between every frame.
    /// </summary>
    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0, Space.Self);
        HandleBobb();
    }

    /// <summary>
    /// Passes the direction vector to DoBobb. The direction flips between moving up or down
    /// based on the coin's position relative to the Bobbing min & max heights.
    /// </summary>
    private void HandleBobb()
    {
        if (transform.position.y > bobbMaxHeight)
        {
            directionFlip = true;
        }
        if (transform.position.y < bobbMinHeight)
        {
            directionFlip = false;
        }
        if (!directionFlip)
        {
            DoBobb(Vector3.up);
        }
        else
        {
            DoBobb(Vector3.down);
        }
    }

    /// <summary>
    /// Moves the coin at a constant speed in the direction passed in.
    /// </summary>
    /// <param name="direction">vector in which to move</param>
    private void DoBobb(Vector3 direction)
    {
        transform.Translate(direction * bobbingSpeed * Time.deltaTime, Space.Self);
    }

    /// <summary>
    /// When the player object enters this coin's trigger range, increase the score by this coin's value,
    /// decrease the current coin count, and destroy this coin.
    /// </summary>
    /// <param name="other">the collider component that entered the trigger range of this coin</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindAnyObjectByType<ScoreManager>().IncreaseScore(pointValue);
            FindAnyObjectByType<CoinSpawner>().DecreaseCoinCount();
            Destroy(this.gameObject);
        }
    }
}
