using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScroller : MonoBehaviour
{
    internal Rigidbody2D rocket;
    public float offsetX, offsetY;
    public RawImage img;
    internal CameraScript cam;
    public float offsetXSpeed, offsetYSpeed;

    void Start()
    {
        rocket = GameObject.Find("Rocket").GetComponent<Rigidbody2D>();
        cam = GameObject.Find("Main Camera").GetComponent<CameraScript>();
    }
        
    void Update()
    {
        if (cam.rocketIsMovingUp == true)
        {
            offsetX += rocket.velocity.x / 100 * Time.deltaTime;
            offsetY += rocket.velocity.y / 100 * Time.deltaTime;
            img.uvRect = new Rect(img.uvRect.position + new Vector2(offsetX, offsetY) * Time.deltaTime,  img.uvRect.size);
        }
        // it now works
    }
}
