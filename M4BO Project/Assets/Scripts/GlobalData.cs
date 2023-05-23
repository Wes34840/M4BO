using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData
{
    // This Class is used to save the data used by all scenes, such as stats for the rocket used in launches but also modified in the upgrades scene

    public static float EndHeight = 10000f;
    public static float Money;

    internal static float MaxFuel = 100f;
    internal static float Thrust = 8f;
    internal static float MaxSpeed = 5f;


    internal static Stat MaxFuelData = new Stat("Max Fuel", 1, 500, 20);
    internal static Stat ThrustData = new Stat("Thrust", 1, 500, 2);
    internal static Stat MaxSpeedData = new Stat("Max Speed", 1, 500, 5);

    public static List<Stat> RocketStats = new List<Stat>()
    {
        MaxFuelData, ThrustData, MaxSpeedData
    };
    public static int MaxFuelLevel;



}
