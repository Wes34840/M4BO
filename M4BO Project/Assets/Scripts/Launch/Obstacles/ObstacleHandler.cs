using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    [SerializeField] private UpdateBackgroundSprites altitudeHandler;

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
        if (rocket.position.y >= rocketPosOnLastObstSpawn.y + 10&& !ObstacleCooldown)
        {
            SpawnObstacle();
            ObstacleCooldown = true; 
            StartCoroutine(WaitForObstacleCooldown());
        }
        else if (rocket.position.y >= rocketPostOnLastCrateSpawn.y + 50 && !CrateCooldown)
        {
            SpawnCrate();
            CrateCooldown = true;
            StartCoroutine(WaitForCrateCooldown());
        }
    }

    internal void SpawnObstacle()
    {
        int altitude = (int)altitudeHandler.currentStage;
        rocketPosOnLastObstSpawn.y = rocket.position.y + 10;
        float offset = Random.Range(-7.0f, 7.0f);
        int obstacleInList = Random.Range(0, ObstacleList[altitude].Length);
        Vector2 point = new Vector2(spawnPoint.position.x + offset, spawnPoint.position.y);
        Instantiate(ObstacleList[altitude][obstacleInList], point, Quaternion.identity);
    }
    internal void SpawnCrate()
    {
        rocketPostOnLastCrateSpawn = rocket.position;
        float offset = Random.Range(-7.0f, 7.0f);
        int crate = Random.Range(0, 2);
        Vector2 point = new Vector2(spawnPoint.position.x + offset, spawnPoint.position.y);
        Instantiate(crates[crate], point, Quaternion.identity);
    }

    private IEnumerator WaitForObstacleCooldown()
    {
        yield return new WaitForSeconds(3);
        ObstacleCooldown = false;
    }
    private IEnumerator WaitForCrateCooldown()
    {
        yield return new WaitForSeconds(10);
        CrateCooldown = false;
    }
 
}
