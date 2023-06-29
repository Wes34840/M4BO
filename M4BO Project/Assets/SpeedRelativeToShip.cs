using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedRelativeToShip : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject rocket;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rocket = GameObject.Find("Rocket");
    }

    // Update is called once per frame
    void Update()
    {
        if (rocket.GetComponent<Rigidbody2D>().velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rocket.GetComponent<Rigidbody2D>().velocity.y*0.8f);
        }
    }
}
