using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObstacleDamageScript : MonoBehaviour
{
    private bool hasDealtDamage = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasDealtDamage && collision.collider.CompareTag("Player")) 
        {
            collision.transform.GetComponent<RocketHealthSystem>().rocketHealth -= 1;
            hasDealtDamage = true;
        }
    }
}
