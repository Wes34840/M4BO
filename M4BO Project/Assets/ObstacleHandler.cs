using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHandler : MonoBehaviour
{

    private Transform spawnPoint;
    private Transform rocket;
    private Vector3 rocketPosOnLastSpawn;

    public GameObject obstaclePrefab;



    void Start()
    {
        rocket = GameObject.Find("Rocket").GetComponent<Transform>();
        spawnPoint = GameObject.Find("ObstacleSpawnPoint").GetComponent<Transform>();
    }

    void Update()
    {
        if (rocket.position.y >= rocketPosOnLastSpawn.y + 10)
        {
            SpawnObstacle();
        }
    }

    internal void SpawnObstacle()
    {
        rocketPosOnLastSpawn = rocket.position;
        int offset = Random.Range(-7, 7);
        Vector2 point = new Vector2(spawnPoint.position.x + offset, spawnPoint.position.y);
        Instantiate(obstaclePrefab, point, Quaternion.identity);
    }
}
