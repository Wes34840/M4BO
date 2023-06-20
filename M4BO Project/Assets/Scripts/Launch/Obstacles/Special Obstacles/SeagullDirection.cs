using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullDirection : MonoBehaviour
{

    Rigidbody2D rb;
    SpriteRenderer sprite;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if (rb.velocity.x < 0)
        {
            sprite.flipX = false;
        }
        else
        {
            sprite.flipX = true;
        }
    }
}
