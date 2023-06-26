using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    bool hasHit;
    internal Vector3 direction;
    float speed = 5;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasHit)
        {
            transform.position += direction * Time.deltaTime * speed;
        }
        Destroy(gameObject, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hasHit = true;
            anim.SetBool("hasHit", true);
            collision.GetComponent<RocketHealthSystem>().rocketHealth -= 5;
        }
        else
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision);
        }
    }
}
