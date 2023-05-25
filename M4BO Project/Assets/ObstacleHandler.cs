using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleHandler : MonoBehaviour
{

    private Transform spawnPoint;
    private Transform rocket;
    private Vector3 rocketPosOnLastSpawn;

    [SerializeField] private GameObject[] lowAltitudeObst, mediumAltitudeObst, highAltitudeObst;


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
        if (rocket.position.y >= rocketPosOnLastSpawn.y + 10) 
        {
            SpawnObstacle();
        }
    }

    internal void SpawnObstacle()
    {
        int altitude = ReturnHeightSet();
        Debug.Log(altitude);
        rocketPosOnLastSpawn = rocket.position;
        int offset = Random.Range(-7, 7);
        int obstacle = Random.Range(0, ObstacleList[altitude].Length);
        Vector2 point = new Vector2(spawnPoint.position.x + offset, spawnPoint.position.y);
        Instantiate(ObstacleList[altitude][obstacle], point, Quaternion.identity);
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
