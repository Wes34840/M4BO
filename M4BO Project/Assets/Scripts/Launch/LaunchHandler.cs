using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LaunchHandler : MonoBehaviour
{
    GameObject Rocket;
    GameObject gameUI;
    GameObject earningsUI, endUI;
    Slider heightSlider;
    public bool GameActive;
    ShowEarnings earningsScript;
    [SerializeField] private Animator endFadeOut;

    void Start()
    {
        Rocket = GameObject.Find("Rocket");
        gameUI = GameObject.Find("GameUI");
        earningsUI = GameObject.Find("EarningsUI");
        endUI = GameObject.Find("EndUI");
        earningsScript = earningsUI.GetComponent<ShowEarnings>();
        heightSlider = GameObject.Find("HeightIndicator").GetComponent<Slider>();
        earningsUI.SetActive(false);
        GameActive = true;
        LaunchData.HeightReached = 0;
        LaunchData.FlightTime = 0;
        LaunchData.CratesPickedUp = 0;
    }
    
    void Update()
    {
        if (Rocket.transform.position.y <= (GameObject.Find("LaunchPad").transform.position.y + 5))
        {
            return;
        }
        else if (GameActive == true)
        {
            LaunchData.FlightTime += Time.deltaTime;
        }

        if (Rocket.transform.position.y < (LaunchData.HeightReached / 10 - 1) && GameActive == true) // if rocket falls too far down
        {
            EndLaunch();
        }
        else if (LaunchData.HeightReached >= GlobalData.EndHeight)
        {
            FinishGame();
        }
    }

    public void EndLaunch()
    {
        LaunchData.HeightReached = heightSlider.value;
        GameActive = false;
        StartCoroutine(EndGameBuffer());
    }

    public void FinishGame()
    {
        endFadeOut.SetBool("FinishedGame", true);
    }

    public IEnumerator EndGameBuffer()
    {
        yield return new WaitForSeconds(2);
        earningsUI.SetActive(true);
        earningsScript.AwardMoney();
    }

}
