using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySelectButton : MonoBehaviour
{
    public AudioSource audioSource;
    public void onClick()
    {
        SceneManager.LoadScene("Upgrade");
        audioSource.Play();
    }


}
