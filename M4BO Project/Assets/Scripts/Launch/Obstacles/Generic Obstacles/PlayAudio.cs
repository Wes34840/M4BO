using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{

    public AudioSource audio;

    private void OnCollisionEnter(Collision collision)
    {
        audio.Play();
    }
}
