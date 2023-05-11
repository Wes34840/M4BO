using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData : MonoBehaviour
{
    // This Class is used to save the data used by all scenes, such as stats for the rocket used in launches but also modified in the upgrades scene

    public static float Thrust = 10f;
    public static float MaxFuel = 100f;
    public static float EndHeight = 10000f;
}
