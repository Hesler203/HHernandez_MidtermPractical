using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health;
    private bool playerDied;

    void Start()
    {
        Debug.Log($"Health: {health}");
    }

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
