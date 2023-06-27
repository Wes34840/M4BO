using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAspectRatio : MonoBehaviour
{
    void Start()
    {
        Screen.SetResolution(607, 1080, FullScreenMode.MaximizedWindow);
    }
}
