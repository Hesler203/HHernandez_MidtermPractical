using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private int maxObstaclesAllowed = 10;
    [SerializeField] private float spawnInterval = 6f;
    private int obstacleCount = 0;
    private float timer;

    void Start()
    {
        timer = spawnInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && obstacleCount < maxObstaclesAllowed)
        {
            SpawnObstacle();
            timer = spawnInterval;
        }
    }

    private void SpawnObstacle()
    {
        Transform randomSpawnPoint = RandomizeSpawnPoint();
        Instantiate(obstaclePrefab, randomSpawnPoint.position, obstaclePrefab.transform.rotation);
        obstacleCount++;
    }

    private Transform RandomizeSpawnPoint()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        return spawnPoints[randomIndex];
    }


    public void DecreaseObstacleCount()
    {
        obstacleCount--;
    }
}
