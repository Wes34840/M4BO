using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeightIndicatorScript : MonoBehaviour
{

    Transform Rocket;
    Slider Indicator;

    // Start is called before the first frame update
    void Start()
    {
        Indicator = GetComponent<Slider>();
        Rocket = GameObject.Find("Rocket").GetComponent<Transform>() ;
        Indicator.maxValue = GlobalData.EndHeight;
    }

    // Update is called once per frame
    void Update()
    {
        Indicator.value = Rocket.position.y;
    }
}
