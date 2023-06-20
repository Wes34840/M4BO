using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    internal Rigidbody2D rocket;
    internal float offsetX, offsetY;
    internal Material mat;
    internal CameraScript cam;

    void Start()
    {
        rocket = GameObject.Find("Rocket").GetComponent<Rigidbody2D>();
        mat = GetComponent<Renderer>().material;
        cam = GameObject.Find("Main Camera").GetComponent<CameraScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cam.rocketIsMovingUp == true)
        {
            offsetX += rocket.velocity.x / 10000f;
            offsetY += rocket.velocity.y / 10000f;
            mat.SetTextureOffset("_MainTex", new Vector2(offsetX, offsetY));
        }
    }
}
