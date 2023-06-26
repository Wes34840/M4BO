using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gullship : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sprite;
    Transform player;
    public GameObject gullLaser;
    bool fireCooldown;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Rocket").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.x < 0)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }

        Vector2 distanceFromPlayer = player.position - transform.position;

        if (distanceFromPlayer.magnitude < 10 && !fireCooldown)
        {
            GameObject bullet = Instantiate(gullLaser, transform.position, Quaternion.identity);
            bullet.GetComponent<ProjectileScript>().direction = new Vector3(distanceFromPlayer.x, distanceFromPlayer.y);
            fireCooldown = true;
            StartCoroutine(WaitForCooldown());
        }
    }
    private IEnumerator WaitForCooldown()
    {
        yield return new WaitForSeconds(2);
        fireCooldown = false;
    }
}
