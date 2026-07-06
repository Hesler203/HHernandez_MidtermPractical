using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnInterval = 10f;
    private int obastacleCount;
    [SerializeField] private int maxObastaclesAllowed = 20;

    void Update()
    {

    }
}
