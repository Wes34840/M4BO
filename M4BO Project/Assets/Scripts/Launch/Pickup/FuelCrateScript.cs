using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCrateScript : MonoBehaviour
{ 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<RocketControls>().Fuel += 50;
            Destroy(gameObject);
        }
    }
}
