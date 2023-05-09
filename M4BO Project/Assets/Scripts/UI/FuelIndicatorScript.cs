using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelIndicatorScript : MonoBehaviour
{

    Slider FuelIndicator;
    RocketControls Rocket;

    // Start is called before the first frame update
    void Start()
    {
        FuelIndicator = GetComponent<Slider>();
        Rocket = GameObject.Find("Rocket").GetComponent<RocketControls>();
        FuelIndicator.maxValue = Rocket.Fuel;
    }

    // Update is called once per frame
    void Update()
    {
        FuelIndicator.value = Rocket.Fuel;
    }
}
