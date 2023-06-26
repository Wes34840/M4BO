using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class UpgradeHandler : MonoBehaviour
{

    private PanelUpdater panelUpdater;
    public AudioSource audio;

    // Fucking hell this took a while
    internal void Start()
    {
        panelUpdater = GetComponent<PanelUpdater>();
    }

    public void UpgradeStat(string buttonArgument)
    {
        Stat[] statArray = GlobalData.RocketStats.Where(i => i.StatName == buttonArgument).ToArray(); // finds stat in RocketStats that has the same name as the buttonargument
        Stat stat = statArray[0];
        if (GlobalData.Money >= stat.StatUpgradeCost)
        {
            GlobalData.Money -= stat.StatUpgradeCost;
            ApplyUpgrade(stat);
        }
        int textFieldIndex = FindPanelTextFields(buttonArgument);
        UpdateUpgradePanel(stat, textFieldIndex);
        audio.Play();
    }
    private void ApplyUpgrade(Stat stat)
    {
        stat.StatLevel++;
        stat.StatUpgradeCost += 500;

        // Pretty much a bandaid fix but I don't fucking care, it works
        GlobalData.MaxFuel = 100 + ((GlobalData.RocketStats[0].StatLevel-1) * GlobalData.RocketStats[0].StatMagnitude);
        GlobalData.Thrust = 8 + ((GlobalData.RocketStats[1].StatLevel-1) * GlobalData.RocketStats[1].StatMagnitude);
        GlobalData.MaxSpeed = 5 + ((GlobalData.RocketStats[2].StatLevel - 1) * GlobalData.RocketStats[2].StatMagnitude);
        GlobalData.MaxHealth = 5 + ((GlobalData.RocketStats[3].StatLevel - 1) * GlobalData.RocketStats[3].StatMagnitude);
        GlobalData.RotationSpeed = 5 + ((GlobalData.RocketStats[4].StatLevel - 1) * GlobalData.RocketStats[4].StatMagnitude);

    }

    private int FindPanelTextFields(string buttonArgument)
    {
        int index = 0;
        foreach (TMP_Text[] TextFields in panelUpdater.PanelTextFields)
        {
            foreach (TMP_Text TextField in TextFields)
            {
                if (TextField.text == buttonArgument)
                {
                    return index; // returns index    -position in PanelTextFields-
                }
            }
            index++; // moves on to next position in PanelTextFields
        }
        // if all else fails, return nothing
        return 0;
    }

    private void UpdateUpgradePanel(Stat stat, int textFieldIndex)
    {
        panelUpdater.DisplayInt(panelUpdater.PanelTextFields[textFieldIndex][1], stat.StatLevel);
        panelUpdater.DisplayInt(panelUpdater.PanelTextFields[textFieldIndex][2], stat.StatUpgradeCost);
    }
}
