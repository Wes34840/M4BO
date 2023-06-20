using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class SeagullDie : MonoBehaviour
{

    Animator anim;
    Rigidbody2D rb;
    Transform rocket;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = transform.parent.GetComponent<Rigidbody2D>();
        rocket = GameObject.Find("Rocket").GetComponent<Transform>();
    }
    void Update()
    {
        if (rocket.position.y >= transform.position.y + 10)
        {
            Destroy(transform.parent, 0.5f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetBool("IsDead", true);
        rb.gravityScale = 0.5f;
        Destroy(transform.parent, 3f);
    }
}
