using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomiseObstacleRot : MonoBehaviour
{
    void Start()
    {
        float rot = Random.Range(-180, 180);
        Debug.Log(rot);
        transform.rotation = Quaternion.Euler(0, 0, rot);     
    }
}
