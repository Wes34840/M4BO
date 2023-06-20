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
        heightEarnings = LaunchData.HeightReached;
        timeEarnings = Mathf.Round(LaunchData.FlightTime * 5);
        pickupEarnings = LaunchData.CratesPickedUp * 500;
        totalEarnings = heightEarnings + timeEarnings + pickupEarnings;
    }

    private void UpdateUI()
    {
        heightEarningsTextField.text = $"Height: \n${heightEarnings}";
        timeEarningsTextField.text = $"Time: \n${timeEarnings}";
        pickupEarningsTextField.text = $"Pickups: \n${pickupEarnings}";
        totalEarningsTextField.text = $"Total: \n${totalEarnings}";
        totalMoneyTextField.text = $"Money: \n${GlobalData.Money}";
    }


    internal void AwardMoney()
    {
        UpdateValues();
        GlobalData.Money += totalEarnings;
    }
}
