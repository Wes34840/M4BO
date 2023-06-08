using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleHandler : MonoBehaviour
{

    private Transform spawnPoint;
    private Transform rocket;
    private Vector3 rocketPosOnLastObstSpawn, rocketPostOnLastCrateSpawn;

    [SerializeField] private GameObject[] lowAltitudeObst, mediumAltitudeObst, highAltitudeObst;
    [SerializeField] private GameObject[] crates;

    List<GameObject[]> ObstacleList = new List<GameObject[]>();

    
        void Start()
    {
        rocket = GameObject.Find("Rocket").GetComponent<Transform>();
        spawnPoint = GameObject.Find("ObstacleSpawnPoint").GetComponent<Transform>();
        ObstacleList.Add(lowAltitudeObst);
        ObstacleList.Add(mediumAltitudeObst);
        ObstacleList.Add(highAltitudeObst);
    }

    void Update()
    {
        if (rocket.position.y >= rocketPosOnLastObstSpawn.y + 15)
        {
            SpawnObstacle();
        }
        else if (rocket.position.y >= rocketPostOnLastCrateSpawn.y + 50)
        {
            SpawnCrate();
        }
    }

    internal void SpawnObstacle()
    {
        int altitude = ReturnHeightSet();
        rocketPosOnLastObstSpawn = rocket.position;
        float offset = Random.Range(-7.0f, 7.0f);
        int obstacle = Random.Range(0, ObstacleList[altitude].Length);
        Vector2 point = new Vector2(spawnPoint.position.x + offset, spawnPoint.position.y);
        Instantiate(ObstacleList[altitude][obstacle], point, Quaternion.identity);
    }

    internal void SpawnCrate()
    {
        rocketPostOnLastCrateSpawn = rocket.position;
        float offset = Random.Range(-7.0f, 7.0f);
        int crate = Random.Range(0, 1);
        Vector2 point = new Vector2(spawnPoint.position.x + offset, spawnPoint.position.y);
        Instantiate(crates[crate], point, Quaternion.identity);
    }

    private int ReturnHeightSet()
    {
        string value = CheckRocketAltitude();        
        return (int)Enum.Parse<Altitudes>(value);
    }

    private string CheckRocketAltitude()
    {
        if (rocket.position.y <= 2000)
        {
            return "Low";
        }
        else if (rocket.position.y <= 5000)
        {
            return "Medium";
        }
        else
        {
            return "High";
        }
    }
}
