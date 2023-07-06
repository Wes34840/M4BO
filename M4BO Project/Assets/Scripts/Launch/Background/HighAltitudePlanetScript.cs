using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HighAltitudePlanetScript : MonoBehaviour
{
    float timer = 20;
    public GameObject[] planets;
    public Transform rocket;
    public UpdateBackgroundSprites altitudeChecker;

    // Update is called once per frame
    void Update()
    {
        if (altitudeChecker.currentStage == Altitudes.High)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                timer = 20;
                Vector3 rocketPos = new Vector3(rocket.position.x, rocket.position.y + 50, rocket.position.z);
                Instantiate(planets[Random.Range(0, 3)], rocketPos, Quaternion.identity);
            }
        }
    }
}
