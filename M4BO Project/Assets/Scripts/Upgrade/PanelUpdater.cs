using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;

public class PanelUpdater : MonoBehaviour
{
    internal List<TMP_Text[]> PanelTextFields = new List<TMP_Text[]>();

    void Start()
    {

        GameObject upgradePanelHolder = GameObject.Find("UpgradePanelHolder");


        Transform[] UpgradePanels = new Transform[upgradePanelHolder.transform.childCount];

        for (int i = 0; i < upgradePanelHolder.transform.childCount; i++)
        {
            UpgradePanels[i] = upgradePanelHolder.transform.GetChild(i);
        }

        int count = 0;
        
        foreach (Transform panel in UpgradePanels)
        {
            Debug.Log(panel.name);
            Transform[] PanelComponents = panel.GetComponentsInChildren<Transform>();
            TMP_Text[] textFields = new TMP_Text[3];
            foreach (Transform panelComponent in PanelComponents)
            {

                if (panelComponent.name == "Name")
                {
                    textFields[0] = panelComponent.GetComponent<TMP_Text>();
                }
                else if (panelComponent.name == "StatLevel")
                {
                    textFields[1] = panelComponent.GetComponent<TMP_Text>();
                    DisplayInt(textFields[1], GlobalData.RocketStats[count].StatLevel);
                }
                else if (panelComponent.name == "Cost")
                {
                    textFields[2] = panelComponent.GetComponent<TMP_Text>();
                    DisplayInt(textFields[2], GlobalData.RocketStats[count].StatUpgradeCost);
                }
            }

            PanelTextFields.Add(textFields);
            count++;
        }

    }

    internal void DisplayInt(TMP_Text textField, int amount)
    {
        textField.text = amount.ToString(); // if amount is under 1000, display normally

        if (amount >= 1000)
        {
            textField.text = (Mathf.Round(amount * 10 / 1000 ) /10) + "K"; // if amount is in the thousands, abbreviate with K
        }
        else if (amount >= 1000000)
        {
            textField.text = (Mathf.Round(amount * 10 / 1000000) / 10) + "M"; // if amount is in the millions, abbreviate with M
        }
    }

}
