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

        TextField.text = GlobalData.Money.ToString();

        if (GlobalData.Money >= 1000)
        {
            TextField.text = (Mathf.Round(GlobalData.Money / 1000 * 10) / 10) + "K";
        }
        else if (GlobalData.Money >= 1000000)
        {
            TextField.text = (Mathf.Round(GlobalData.Money / 1000 * 10) / 10) + "M";
        }
    }
}
