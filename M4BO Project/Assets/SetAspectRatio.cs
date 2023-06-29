using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAspectRatio : MonoBehaviour
{
    void Start()
    {
        Screen.SetResolution((Screen.height / 16 * 9), Screen.height, FullScreenMode.MaximizedWindow);
    }
}
