using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowEarnings : MonoBehaviour
{
    TMP_Text heightEarningsTextField, timeEarningsTextField, pickupEarningsTextField, totalEarningsTextField, totalMoneyTextField;
    private float heightEarnings, timeEarnings, pickupEarnings = 0;
    public float totalEarnings = 0;


    void Start()
    {
        heightEarningsTextField = GameObject.Find("HeightEarnings").GetComponent<TMP_Text>();
        timeEarningsTextField = GameObject.Find("FlightTimeEarnings").GetComponent<TMP_Text>();
        pickupEarningsTextField = GameObject.Find("PickupEarnings").GetComponent<TMP_Text>();
        totalEarningsTextField = GameObject.Find("TotalEarnings").GetComponent<TMP_Text>();
        totalMoneyTextField = GameObject.Find("TotalMoney").GetComponent <TMP_Text>();
    }

    void Update()
    {

        UpdateValues();
        UpdateUI();
    }

    private void UpdateValues()
    {
        heightEarnings = Mathf.Round(LaunchData.HeightReached * 20);
        timeEarnings = Mathf.Round(LaunchData.FlightTime * 5);
        pickupEarnings = LaunchData.CratesPickedUp * 500;
        totalEarnings = heightEarnings + timeEarnings + pickupEarnings;
    }

    private void UpdateUI()
    {
        heightEarningsTextField.text = "Height: " + heightEarnings;
        timeEarningsTextField.text = "Time; " + timeEarnings;
        pickupEarningsTextField.text = "Pickups: " + pickupEarnings;
        totalEarningsTextField.text = "Total Earned: " + totalEarnings;
        totalMoneyTextField.text = "Money: " + (GlobalData.Money += totalEarnings);
    }
    
    internal void AwardMoney()
    {
        UpdateValues();
        GlobalData.Money += totalEarnings;
    }
}
