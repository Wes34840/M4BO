using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeightIndicatorScript : MonoBehaviour
{

    Transform Rocket;
    Slider Indicator;
    TMP_Text textIndicator;
    CameraScript cam;

    // Start is called before the first frame update
    void Start()
    {
        Indicator = GetComponent<Slider>();
        textIndicator = GameObject.Find("Height but in numbers").GetComponent<TMP_Text>();
        Rocket = GameObject.Find("Rocket").GetComponent<Transform>() ;
        cam = GameObject.Find("Main Camera").GetComponent<CameraScript>();
        Indicator.maxValue = GlobalData.EndHeight;
    }

    // Update is called once per frame
    void Update()
    {
        if (cam.rocketIsMovingUp == true)
        {
            Indicator.value = Rocket.position.y;
        }
        textIndicator.text = "" + Mathf.Round((Rocket.position.y * 10) - 11);
    }
}
