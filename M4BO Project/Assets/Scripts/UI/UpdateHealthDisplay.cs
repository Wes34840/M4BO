using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateHealthDisplay : MonoBehaviour
{

    RocketHealthSystem healthSystem;
    public TMP_Text textField;
    // Start is called before the first frame update
    void Start()
    {
        healthSystem = GameObject.Find("Rocket").GetComponent<RocketHealthSystem>();
    }

    void Update()
    {
        textField.text = healthSystem.rocketHealth.ToString();
    }
}
