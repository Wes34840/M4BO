using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObstacleScript : MonoBehaviour
{

    [SerializeField] private float slowMagnitude;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / slowMagnitude);
        
    }
}
