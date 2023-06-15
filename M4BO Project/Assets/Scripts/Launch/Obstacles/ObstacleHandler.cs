using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ObstacleHandler : MonoBehaviour
{

    private Transform spawnPoint, rocket;
    public Vector3 rocketPosOnLastObstSpawn = new Vector3 (0, 25, 0);
    public Vector3 rocketPostOnLastCrateSpawn = new Vector3(0,55,0);
    private Slider Indicator;
    private bool ObstacleCooldown, CrateCooldown;

    [SerializeField] private GameObject[] lowAltitudeObst, mediumAltitudeObst, highAltitudeObst, crates;

    List<GameObject[]> ObstacleList = new List<GameObject[]>();

    
        void Start()
    {
        rocket = GameObject.Find("Rocket").GetComponent<Transform>();
        spawnPoint = GameObject.Find("ObstacleSpawnPoint").GetComponent<Transform>();
        Indicator = GameObject.Find("HeightIndicator").GetComponent<Slider>();
        ObstacleList.Add(lowAltitudeObst);
        ObstacleList.Add(mediumAltitudeObst);
        ObstacleList.Add(highAltitudeObst);
        StartCoroutine(WaitForObstacleCooldown());
        StartCoroutine(WaitForCrateCooldown());
    }

    void Update()
    {
        if (rocket.position.y >= rocketPosOnLastObstSpawn.y && !ObstacleCooldown)
        {
            SpawnObstacle();
            ObstacleCooldown = true; 
            StartCoroutine(WaitForObstacleCooldown());
        }
        else if (rocket.position.y >= rocketPostOnLastCrateSpawn.y && !CrateCooldown)
        {
            SpawnCrate();
            CrateCooldown = true;
            StartCoroutine(WaitForCrateCooldown());
        }
    }

    internal void SpawnObstacle()
    {
        int altitude = ReturnHeightSet();
        rocketPosOnLastObstSpawn.y = rocket.position.y + 10;
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
        if (Indicator.value <= GlobalData.EndHeight / 5)
        {
            return "Low";
        }
        else if (Indicator.value <= GlobalData.EndHeight / 2)
        {
            return "Medium";
        }
        else
        {
            return "High";
        }
    }
    private IEnumerator WaitForObstacleCooldown()
    {
        yield return new WaitForSeconds(2);
        ObstacleCooldown = false;
    }
    private IEnumerator WaitForCrateCooldown()
    {
        yield return new WaitForSeconds(5);
        CrateCooldown = false;
    }
}
