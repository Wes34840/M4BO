using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public AudioSource audioSource;
    public void GoToScene(string sceneName)
    {
        audioSource.Play();
        SceneManager.LoadScene(sceneName);
    }


}
