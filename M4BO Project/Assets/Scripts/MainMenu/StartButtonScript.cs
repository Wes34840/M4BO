using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonScript : MonoBehaviour
{
    public GameObject startMenu, difficultySelectMenu;
    public AudioSource audio;
    public void onClick()
    {
        audio.Play();
        startMenu.SetActive(false);
        difficultySelectMenu.SetActive(true);
    }
}
