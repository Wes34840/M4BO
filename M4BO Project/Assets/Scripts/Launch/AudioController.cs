using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip mediumAltMusic, highAltMusic;
    public void LowToMedium()
    {
        audioSource.Stop();
        audioSource.clip = mediumAltMusic;
        audioSource.Play();
    }
    public void MediumToHigh()
    {
        audioSource.Stop();
        audioSource.clip = highAltMusic;
        audioSource.Play();
    }
}
