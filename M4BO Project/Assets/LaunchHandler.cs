using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LaunchHandler : MonoBehaviour
{
    GameObject Rocket;
    GameObject gameUI;
    GameObject earningsUI;
    Slider heightSlider;


    void Start()
    {
        Rocket = GameObject.Find("Rocket");
        gameUI = GameObject.Find("GameUI");
        earningsUI = GameObject.Find("earningsUI");
        heightSlider = GameObject.Find("HeightIndicator").GetComponent<Slider>();
        earningsUI.SetActive(false);
    }
    
    void Update()
    {
        
    }

    void EndLaunch()
    {
        Rocket.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        LaunchData.HeightReached = heightSlider.value;
        gameUI.SetActive(false);
        earningsUI.SetActive(true);
    }

}
