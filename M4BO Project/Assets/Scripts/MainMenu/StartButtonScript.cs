using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonScript : MonoBehaviour
{
    public GameObject startMenu, difficultySelectMenu;
    public AudioSource audioSource;
    public void GoToDifficultySelect()
    {
        audioSource.Play();
        startMenu.SetActive(false);
        difficultySelectMenu.SetActive(true);
    }
    public void BackToMainMenu()
    {
        audioSource.Play();
        startMenu.SetActive(true);
        difficultySelectMenu.SetActive(false);
    }
}
