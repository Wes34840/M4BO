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
        Transform[] UpgradePanels = GameObject.Find("UpgradePanelHolder").GetComponentsInChildren<Transform>();
        foreach (Transform panel in UpgradePanels)
        {
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
                }
                else if (panelComponent.name == "Cost")
                {
                    textFields[2] = panelComponent.GetComponent<TMP_Text>();
                }
            }

            PanelTextFields.Add(textFields);
        }

    }

}
