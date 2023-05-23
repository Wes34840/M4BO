using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat
{
    public string StatName;
    public int StatLevel;
    public int StatUpgradeCost;
    public int StatMagnitude;

    public Stat (string statName, int statLevel, int statUpgradeCost, int statMagnitude)
    {
        StatName = statName;
        StatLevel= statLevel;
        StatUpgradeCost= statUpgradeCost;
        StatMagnitude= statMagnitude;
    }

}
