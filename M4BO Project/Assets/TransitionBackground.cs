using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionBackground : MonoBehaviour
{
    public RawImage backgroundImage;
    public Texture2D mediumAltBackground, highAltBackground;

    public void SwitchToMedium()
    {
        backgroundImage.texture = mediumAltBackground;
    }
    public void SwitchToHigh()
    {
        backgroundImage.texture = highAltBackground;
    }
}
