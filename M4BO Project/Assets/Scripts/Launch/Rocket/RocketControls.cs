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

    internal Rigidbody2D rb;
    internal Animator anim;

    internal LaunchHandler launchHandler;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        maxFuel = GlobalData.MaxFuel;
        Fuel =  maxFuel;
        launchHandler = GameObject.Find("Game Handler").GetComponent<LaunchHandler>();

        anim = GameObject.Find("RocketSprite").GetComponent<Animator>();
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
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
            }
            else
            {
                anim.SetBool("hasThrust", false);
                audioSource.Stop();
            }
            rb.AddForce(DirX * GlobalData.HorizontalSpeed * transform.right);
            EnforceMaxHorizontalSpeed();
            
        }

    }

    private void Thrust()
    {
        rb.AddForce(DirY * GlobalData.Thrust * transform.up);
        if (rb.velocity.y >= GlobalData.MaxSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, GlobalData.MaxSpeed);
        }
        Fuel -= 0.1f;
        anim.SetBool("hasThrust", true);
    }

    internal void EnforceMaxHorizontalSpeed()
    {
        if (rb.velocity.x > 7)
        {
            rb.velocity = new Vector2(7, rb.velocity.y);
        }
        else if (rb.velocity.x < -7)
        {
            rb.velocity = new Vector2(-7, rb.velocity.y);
        }
    }
    internal void UpdateRocketSprite()
    {
        if (DirX < 0)
        {
            anim.SetBool("IsTurningRight", false);
            anim.SetBool("IsTurningLeft", true);
        }
        else if (DirX > 0)
        {
            anim.SetBool("IsTurningLeft", false);
            anim.SetBool("IsTurningRight", true);
        }
        // this sucks, but I gotta do this fast
    }
}
