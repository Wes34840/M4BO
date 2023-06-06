using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaunchHandler : MonoBehaviour
{
    GameObject Rocket;
    GameObject gameUI;
    GameObject earningsUI;
    Slider heightSlider;
    public bool GameActive;
    ShowEarnings earningsScript;

    void Start()
    {
        Rocket = GameObject.Find("Rocket");
        gameUI = GameObject.Find("GameUI");
        earningsUI = GameObject.Find("EarningsUI");
        earningsScript = earningsUI.GetComponent<ShowEarnings>();
        heightSlider = GameObject.Find("HeightIndicator").GetComponent<Slider>();
        earningsUI.SetActive(false);
        GameActive = true;

        LaunchData.FlightTime = 0;
    }
    
    void Update()
    {
        if (Rocket.transform.position.y <= (GameObject.Find("Ground").transform.position.y + 1))
        {
            return;
        }
        else if (GameActive == true)
        {
            LaunchData.FlightTime += Time.deltaTime;
        }

        if (Rocket.transform.position.y < (heightSlider.value - 4f) && GameActive == true) // if rocket falls too far down
        {
            EndLaunch();
        }
    }

    public void EndLaunch()
    {
        gameUI.SetActive(false);
        LaunchData.HeightReached = heightSlider.value;
        earningsUI.SetActive(true);
        GameActive = false;
        Debug.Log("Awarded money");
        earningsScript.AwardMoney();
    }

}
