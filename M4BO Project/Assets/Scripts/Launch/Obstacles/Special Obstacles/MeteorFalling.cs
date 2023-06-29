using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorFalling : MonoBehaviour
{
    internal Vector3 velocity;
    private GameObject rocket;
    private SpriteRenderer sprite;
    private void Start()
    {
        rocket = GameObject.Find("Rocket");
        sprite = GetComponent<SpriteRenderer>();
        if (transform.position.x <= rocket.transform.position.x)
        {
            velocity = new Vector3(2, 0, 0);
            sprite.flipX = true;
        }
        else if (transform.position.x > rocket.transform.position.x)
        {
            velocity = new Vector3(-2, 0, 0);
            sprite.flipX = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        velocity = new Vector2(velocity.x, rocket.GetComponent<Rigidbody2D>().velocity.y);
        transform.position += velocity * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            rb.velocity -= rb.velocity / 4; //lose a quarter of your speed
            RocketHealthSystem rocket = collision.transform.GetComponent<RocketHealthSystem>();
            rocket.rocketHealth -= 10;
            StartCoroutine(rocket.TriggerHurtAnimation());
            Destroy(gameObject, 0.5f);
        }

    }
}
