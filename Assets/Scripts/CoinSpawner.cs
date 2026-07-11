using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] coinPrefabs;
    [SerializeField] private int maxCoinsAllowed = 20;
    private const int INTIAL_SPAWN_COUNT = 5;
    [SerializeField] private float spawnInterval = 4f;
    private int coinCount = 0;
    private float timer;

    void Start()
    {
        timer = spawnInterval;
        SpawnInitialCoins();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && coinCount < maxCoinsAllowed)
        {
            SpawnCoin();
            timer = spawnInterval;
        }
    }

    private void SpawnInitialCoins()
    {
        for (int i = 0; i < INTIAL_SPAWN_COUNT; i++)
        {
            SpawnCoin();
        }
    }

    private void SpawnCoin()
    {
        GameObject randomCoin = RandomizeCoinToSpawn();
        Vector3 randomLocation = RandomizeSpawnLocation(randomCoin.transform);
        Instantiate(randomCoin, randomLocation, randomCoin.transform.rotation);
        coinCount++;
    }

    private GameObject RandomizeCoinToSpawn()
    {
        int randomIndex = Random.Range(0, coinPrefabs.Length);
        return coinPrefabs[randomIndex];
    }

    private Vector3 RandomizeSpawnLocation(Transform coinTransform)
    {
        Vector3 coinSpawnHeight = new Vector3(0, coinTransform.position.y, 0);
        return PlayAreaBounds.RandomLocationInPlayArea() + coinSpawnHeight;
    }

    public void DecreaseCoinCount()
    {
        coinCount--;
    }
}
