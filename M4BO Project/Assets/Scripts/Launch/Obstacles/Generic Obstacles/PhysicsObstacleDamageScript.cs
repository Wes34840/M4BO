using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObstacleDamageScript : MonoBehaviour
{
    private bool hasDealtDamage = false;
    public int damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasDealtDamage && collision.collider.CompareTag("Player"))
        {
            RocketHealthSystem rocket = collision.transform.GetComponent<RocketHealthSystem>();
            rocket.rocketHealth -= damage;
            StartCoroutine(rocket.TriggerHurtAnimation());
            hasDealtDamage = true;
        }
        else
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }
}
