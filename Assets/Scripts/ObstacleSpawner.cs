using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private int maxObstaclesAllowed = 10;
    [SerializeField] private float spawnInterval = 6f;
    private int obstacleCount = 0;
    private float timer;

    /// <summary>
    /// Initialize the spawn timer for obstacle spawning.
    /// </summary>
    void Start()
    {
        timer = spawnInterval;
    }

    /// <summary>
    /// Decreases the spawn timer over time between every frame, and spawns an obstacle once the
    /// timer runs up & resets the spawn timer. Obstacles will only spawn when the current
    /// obstacle count is less than the max allowed.
    /// </summary>
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && obstacleCount < maxObstaclesAllowed)
        {
            SpawnObstacle();
            timer = spawnInterval;
        }
    }

    /// <summary>
    /// Spawns an obstacle at a random spawn point within the spawn points array &
    /// increases the current obstacle count by 1.
    /// </summary>
    private void SpawnObstacle()
    {
        Transform randomSpawnPoint = RandomizeSpawnPoint();
        Instantiate(obstaclePrefab, randomSpawnPoint.position, obstaclePrefab.transform.rotation);
        obstacleCount++;
    }

    /// <summary>
    /// Picks a random spawn point within the spawn points array
    /// and returns a reference to its transform component.
    /// </summary>
    /// <returns>a reference to the random spawn point's transform component</returns>
    private Transform RandomizeSpawnPoint()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        return spawnPoints[randomIndex];
    }

    /// <summary>
    /// Decreases the current obstacle count by 1, called before an obstacle is destroyed.
    /// </summary>
    public void DecreaseObstacleCount()
    {
        obstacleCount--;
    }
}
