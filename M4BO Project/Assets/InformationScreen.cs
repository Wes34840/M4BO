using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationScreen : MonoBehaviour
{
    public GameObject  infoScreen;
    public AudioSource audioSource;
    public AudioClip clip;
    public void OpenInformationScreen()
    {
        infoScreen.SetActive(true);
        audioSource.PlayOneShot(clip);
    }
    public void CloseInformationScreen()
    {
        infoScreen.SetActive(false); 
        audioSource.PlayOneShot(clip);
    }
}
