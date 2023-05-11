using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowEarnings : MonoBehaviour
{
    TMP_Text heightEarningsTextField;
    TMP_Text totalEarningsTextField;

    private float heightEarnings, totalEarnings;



    void Start()
    {
        heightEarningsTextField = GameObject.Find("HeightEarnings").GetComponent<TMP_Text>();
        totalEarningsTextField = GameObject.Find("TotalEarnings").GetComponent<TMP_Text>();
    }

    void Update()
    {

        UpdateValues();
        UpdateUI();
    }

    private void UpdateValues()
    {
        heightEarnings = LaunchData.HeightReached * 100;
        totalEarnings = heightEarnings;
    }

    private void UpdateUI()
    {
        heightEarningsTextField.text = "Height: " + heightEarnings;
        totalEarningsTextField.text = "Total: " + totalEarnings;
    }
}
