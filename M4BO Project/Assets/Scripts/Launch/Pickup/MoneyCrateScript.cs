using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCrateScript : MonoBehaviour
{
    public AudioSource audio;
    public GameObject childSprite;
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.CompareTag("Player"))
        {
            LaunchData.CratesPickedUp++;
            Destroy(childSprite);
            audio.Play();
            Destroy(gameObject, 5f);
        }
    }
}
