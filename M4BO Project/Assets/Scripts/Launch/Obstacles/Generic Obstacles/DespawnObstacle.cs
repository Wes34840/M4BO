using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnObstacle : MonoBehaviour
{
    private Transform rocket;
    private Rigidbody2D rb;
    private void Start()
    {
        rocket = GameObject.Find("Rocket").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (rocket.position.y >= transform.position.y + 10)
        {
            Destroy(gameObject, 0.5f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            rb.gravityScale = 0.5f;
            Destroy(gameObject, 3f);
        }
    }

}
