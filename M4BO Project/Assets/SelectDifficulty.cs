using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectDifficulty : MonoBehaviour
{
    [SerializeField] GameObject PlayScreen, StartScreen;
    public void EasyDifficulty ()
    {
        // Pass 'Easy' on to whatever script handles difficulty

        SceneManager.LoadScene("Upgrade");
    }

    public void ReturnToStart ()
    {
        PlayScreen.SetActive(false);
        StartScreen.SetActive(true);
    }
}
