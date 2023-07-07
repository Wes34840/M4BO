using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class RocketControls : MonoBehaviour
{
    internal float bufferTime = 3;
    
    internal float maxFuel;
    internal float Fuel;

    internal Rigidbody2D rb;
    internal Animator anim;

    public float horizontalInput;
    public float verticalInput;

    internal LaunchHandler launchHandler;

    public AudioSource audioSource;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        maxFuel = GlobalData.MaxFuel;
        Fuel = maxFuel;
        launchHandler = GameObject.Find("Game Handler").GetComponent<LaunchHandler>();

        anim = GameObject.Find("RocketSprite").GetComponent<Animator>();
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        horizontalInput = ctx.ReadValue<float>();
        rb.AddForce(horizontalInput * GlobalData.HorizontalSpeed * transform.right);
    }

    public void PauseThruster(InputAction.CallbackContext ctx)
    {
        verticalInput = ctx.ReadValue<float>();
    }

    void FixedUpdate()
    { 
        // wait till 3 seconds have passed so people can react to
        // the great scenery that is totally not clipping inside of itself lmfao
        if (bufferTime > 0) 
        {
            bufferTime -= Time.deltaTime;
        }

        // I FUCKING LOVE IF STATEMENTS
        if (launchHandler.GameActive)
        {
            if (Fuel > 0 && verticalInput == 0)
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

            rb.AddForce(horizontalInput * GlobalData.HorizontalSpeed * transform.right);

            EnforceMaxHorizontalSpeed();
            anim.SetFloat("Direction", horizontalInput);
        }

    }

    private void Thrust()
    {
        rb.AddForce(GlobalData.Thrust * transform.up);
        if (rb.velocity.y >= GlobalData.MaxSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, GlobalData.MaxSpeed);
        }
        Fuel -= 0.1f;
        anim.SetBool("hasThrust", true);
    }

    internal void EnforceMaxHorizontalSpeed()
    {
        if (rb.velocity.x > 9)
        {
            rb.velocity = new Vector2(9, rb.velocity.y);
        }
        else if (rb.velocity.x < -9)
        {
            rb.velocity = new Vector2(-9, rb.velocity.y);
        }
    }
}
