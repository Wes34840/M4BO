using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelUpdater : MonoBehaviour
{
    internal List<TMP_Text[]> PanelTextFields = new List<TMP_Text[]>();

    // Start is called before the first frame update
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
                string statLevel = GlobalData.RocketStats[count].StatLevel.ToString();
                string statUpgradeCost = GlobalData.RocketStats[count].StatUpgradeCost.ToString();

                if (panelComponent.name == "Name")
                {
                    textFields[0] = panelComponent.GetComponent<TMP_Text>();
                }
                else if (panelComponent.name == "StatLevel")
                {
                    textFields[1] = panelComponent.GetComponent<TMP_Text>();
                    textFields[1].text = statLevel;
                }
                else if (panelComponent.name == "Cost")
                {
                    textFields[2] = panelComponent.GetComponent<TMP_Text>();
                    textFields[2].text = "Cost: " + statUpgradeCost;
                }
            }

            PanelTextFields.Add(textFields);
            count++;
        }

    }

}
