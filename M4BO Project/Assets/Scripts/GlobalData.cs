using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData
{
    // This Class is used to save the data used by all scenes, such as stats for the rocket used in launches but also modified in the upgrades scene

    public static float EndHeight = 100000f;
    public static float Money = 1500000f;

    internal static float MaxFuel = 100f;
    internal static float Thrust = 10f;
    internal static float MaxSpeed = 5f;
    internal static float MaxHealth = 5f;
    internal static float HorizontalSpeed = 8f;

    internal static Stat MaxFuelData = new Stat("Max Fuel", 1, 500, 20);
    internal static Stat ThrustData = new Stat("Thrust", 1, 500, 2);
    internal static Stat MaxSpeedData = new Stat("Max Speed", 1, 500, 3);
    internal static Stat MaxHealthData = new Stat("Max Health", 1, 500, 2);
    internal static Stat HorizontalSpeedData = new Stat("Horizontal Speed", 1, 500, 2);

    public static List<Stat> RocketStats = new List<Stat>(3)
    {
        MaxFuelData, ThrustData, MaxSpeedData, MaxHealthData, HorizontalSpeedData
    };



}
