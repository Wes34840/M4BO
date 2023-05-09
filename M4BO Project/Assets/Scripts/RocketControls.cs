using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketControls : MonoBehaviour
{
    internal float DirX;
    internal float DirY;

    internal float Fuel = GlobalData.MaxFuel;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DirX = Input.GetAxisRaw("Horizontal");
        DirY = Input.GetAxisRaw("Vertical");
        if (DirY > 0)
        {
            Thrust();
        }

        rb.rotation -= DirX * 1.5f;

    }

    void Thrust()
    {
        rb.AddForce(DirY * GlobalData.Thrust * transform.up);
        Fuel -= 0.1f;
    }
}
