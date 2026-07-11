using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] coinPrefabs;
    [SerializeField] private int maxCoinsAllowed = 20;
    private const int INTIAL_SPAWN_COUNT = 5;
    [SerializeField] private float spawnInterval = 4f;
    private int coinCount = 0;
    private float timer;

    /// <summary>
    /// Initializes the spawn timer for recurring spawns & spawns the inital coins.
    /// </summary>
    void Start()
    {
        timer = spawnInterval;
        SpawnInitialCoins();
    }

    /// <summary>
    /// Decreases the spawn timer over time, and spawns a new coin when the timer is up before
    /// resetting the timer, allowing for recurring spawns while the max coin limit hasn't been reached.
    /// </summary>
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && coinCount < maxCoinsAllowed)
        {
            SpawnCoin();
            timer = spawnInterval;
        }
    }

    /// <summary>
    /// Repeatedly spawns coins until the intial spawn count is reached
    /// </summary>
    private void SpawnInitialCoins()
    {
        for (int i = 0; i < INTIAL_SPAWN_COUNT; i++)
        {
            SpawnCoin();
        }
    }

    /// <summary>
    /// Spawns a random coin in a randomly generated location within the play area bounds
    /// before increasing the current coin count.
    /// </summary>
    private void SpawnCoin()
    {
        GameObject randomCoin = RandomizeCoinToSpawn();
        Vector3 randomLocation = RandomizeSpawnLocation(randomCoin.transform);
        Instantiate(randomCoin, randomLocation, randomCoin.transform.rotation);
        coinCount++;
    }

    /// <summary>
    /// Retruns a reference to a random coin in the coin prefabs array
    /// </summary>
    /// <returns>reference to a random coin Prefab</returns>
    private GameObject RandomizeCoinToSpawn()
    {
        int randomIndex = Random.Range(0, coinPrefabs.Length);
        return coinPrefabs[randomIndex];
    }

    /// <summary>
    /// Returns a randomly generated position within the play area bounds at the coin prefab's height.
    /// </summary>
    /// <param name="coinTransform">Transform component of the random coin to spawn</param>
    /// <returns></returns>
    private Vector3 RandomizeSpawnLocation(Transform coinTransform)
    {
        Vector3 coinSpawnHeight = new Vector3(0, coinTransform.position.y, 0);
        return PlayAreaBounds.RandomLocationInPlayArea() + coinSpawnHeight;
    }

    /// <summary>
    /// Decreases the current coin count by one, called when the player collects a coin.
    /// </summary>
    public void DecreaseCoinCount()
    {
        coinCount--;
    }
}
