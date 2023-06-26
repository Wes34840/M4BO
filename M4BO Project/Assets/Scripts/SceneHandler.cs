using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public AudioSource audio;
    public void GoToScene(string sceneName)
    {
        audio.Play();
        SceneManager.LoadScene(sceneName);
    }


}
