using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateBackgroundHolderPosition : MonoBehaviour
{
    GameObject rocket;
    CameraScript cam;

    void Start()
    {
        rocket = GameObject.Find("Rocket");
        cam = GameObject.Find("Main Camera").GetComponent<CameraScript>();
    }
    
    void Update()
    {
        if (cam.rocketIsMovingUp)
        {
            transform.position = new Vector3(rocket.transform.position.x, rocket.transform.position.y + 26, 1);
        }
    }
}
