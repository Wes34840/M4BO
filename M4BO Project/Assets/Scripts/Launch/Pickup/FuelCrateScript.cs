using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCrateScript : MonoBehaviour
{
    private void Update()
    {
        Destroy(gameObject, 10);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<RocketControls>().Fuel += 50;
    }
}
