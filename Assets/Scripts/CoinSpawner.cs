using Unity.VisualScripting;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] coinPrefabs;
    [SerializeField] private int initialSpawnCount = 5;
    [SerializeField] private float spawnInterval = 10f;
    private int coinCount;
    [SerializeField] private int maxCoinsAllowed = 20;

    void Start()
    {
        SpawnInitialCoins();
    }

    void Update()
    {
        if (coinCount < maxCoinsAllowed)
        {
            SpawnRecurringCoins();
        }
    }

    private void SpawnInitialCoins()
    {
        for (int i = 0; i < initialSpawnCount; i++)
        {
            SpawnCoin();
        }
    }

    private void SpawnRecurringCoins()
    {
        spawnInterval *= Random.value;
        do
        {
            spawnInterval -= Time.deltaTime;
        } while (spawnInterval > 0);
        SpawnCoin();
    }

    private void SpawnCoin()
    {

        int randomIndex = Random.Range(0, coinPrefabs.Length);
        GameObject randomCoin = coinPrefabs[randomIndex];
        Vector3 coinSpawnHeight = new Vector3(0, randomCoin.transform.position.y, 0);
        Vector3 randomLocation = PlayAreaBounds.RandomLocationInPlayArea() + coinSpawnHeight;
        Instantiate(randomCoin, randomLocation, randomCoin.transform.rotation);
        coinCount++;
    }
}
