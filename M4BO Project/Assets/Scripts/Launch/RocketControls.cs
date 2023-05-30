using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RocketControls : MonoBehaviour
{
    internal float DirX;
    internal float DirY;

    internal float maxFuel;
    internal float Fuel;
    Rigidbody2D rb;

    internal LaunchHandler launchHandler;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        maxFuel = GlobalData.MaxFuel;
        Fuel =  maxFuel;
        launchHandler = GameObject.Find("Game Handler").GetComponent<LaunchHandler>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (launchHandler.GameActive)
        {
            DirX = Input.GetAxisRaw("Horizontal");
            DirY = Input.GetAxisRaw("Vertical");
            if (Fuel > 0 && DirY > 0)
            {
                Thrust();
            }
            rb.rotation -= (DirX / 2f);
        }

    }

    private void Thrust()
    {
        Debug.Log(GlobalData.MaxSpeed);

        rb.AddForce(DirY * GlobalData.Thrust * transform.up);

        if (rb.velocity.y >= GlobalData.MaxSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, GlobalData.MaxSpeed);
        }
        Fuel -= 0.1f;
    }
}
