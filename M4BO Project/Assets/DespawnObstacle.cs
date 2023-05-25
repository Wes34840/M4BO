using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnObstacle : MonoBehaviour
{
    private Transform rocket;

    private void Start()
    {
        rocket = GameObject.Find("Rocket").GetComponent<Transform>();
    }

    private void Update()
    {
        if (rocket.position.y >= transform.position.y + 5)
        {
            Destroy(gameObject, 0.5f);
        }
    }

}
