using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorFalling : MonoBehaviour
{
    Vector3 velocity;
    private Transform rocketPos;
    private SpriteRenderer sprite;
    private void Start()
    {
        rocketPos = GameObject.Find("Rocket").GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
        if (transform.position.x <= rocketPos.position.x)
        {
            velocity = new Vector3(2, -4, 0);
            sprite.flipX = true;
        }
        else if (transform.position.x > rocketPos.position.x)
        {
            velocity = new Vector3(-2, -4, 0);
            sprite.flipX = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            rb.velocity -= rb.velocity / 4; //lose a quarter of your speed
            collision.transform.GetComponent<RocketHealthSystem>().rocketHealth -= 1;
            Destroy(gameObject, 0.5f);
        }
        else
        {
            return;
        }

    }
}
