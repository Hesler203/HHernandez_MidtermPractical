using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float health;
    private bool playerDied;

    void Update()
    {
        if (playerDied)
        {
            GetComponent<PlayerController>().enabled = false;
            //FindAnyObjectByType<ObstacleSpawner>().enabled = false;
            FindAnyObjectByType<CoinSpawner>().enabled = false;
        }
    }

    public void TakeDamage(float damage)
    {
        if (health > 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
            playerDied = true;
        }
    }

}
