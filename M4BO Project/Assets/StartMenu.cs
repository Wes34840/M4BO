using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] GameObject PlayScreen, StartScreen;
    public void SelectDifficulty ()
    {
        PlayScreen.SetActive(true);
        StartScreen.SetActive(false);
    }
}
