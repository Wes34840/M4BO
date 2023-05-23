using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowMoneyInShop : MonoBehaviour
{

    TMP_Text TextField;
    // Start is called before the first frame update
    void Start()
    {
        TextField = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        TextField.text = "Money: " + GlobalData.Money;
    }
}
