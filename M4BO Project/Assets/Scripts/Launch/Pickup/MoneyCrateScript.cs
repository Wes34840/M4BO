using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCrateScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LaunchData.CratesPickedUp++;
        Destroy(gameObject);
    }
}
