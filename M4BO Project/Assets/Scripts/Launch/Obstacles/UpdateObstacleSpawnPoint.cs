using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateObstacleSpawnPoint : MonoBehaviour
{

    private Transform target;

    void Start()
    {
        target = GameObject.Find("Rocket").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(target.position.x, target.position.y + 15);
    }
}
