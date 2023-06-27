using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCrateScript : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject childSprite;
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.CompareTag("Player"))
        {
            LaunchData.CratesPickedUp++;
            Destroy(childSprite);
            audioSource.Play();
            Destroy(gameObject, 5f);
        }
    }
}
