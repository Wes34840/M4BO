using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneDirection : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
