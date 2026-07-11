using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health;
    private bool playerDied;

    /// <summary>
    /// Displays initial health to the player.
    /// </summary>
    void Start()
    {
        Debug.Log($"Health: {health}");
    }

    /// <summary>
    /// Disables player movement and obstacle & coin spawning,
    /// and displays a loss message when the player has died.
    /// </summary>
    void Update()
    {
        if (playerDied)
        {
            GetComponent<PlayerController>().enabled = false;
            FindAnyObjectByType<ObstacleSpawner>().enabled = false;
            FindAnyObjectByType<CoinSpawner>().enabled = false;

            Debug.Log("You have lost. Player has died...");
        }
    }

    /// <summary>
    /// Decreases player health by the damage amount passed in during obstacle collision
    /// & displays the updated health value. Flips the playerDied flag when health drops to 0 or below.
    /// </summary>
    /// <param name="damage">int value passed in by the obstacle collided with</param>
    public void TakeDamage(int damage)
    {
        if (health > 0)
        {
            health -= damage;
            Debug.Log($"Damage taken. Health is now {health}.");
        }
        else
        {
            health = 0;
            playerDied = true;
        }
    }
}
