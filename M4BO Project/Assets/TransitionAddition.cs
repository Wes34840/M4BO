using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionAddition : MonoBehaviour
{
    public RawImage additionImage;
    public Texture2D mediumAltAddition, highAltAddition;

    public void SwitchToMedium()
    {
        additionImage.texture = mediumAltAddition;
    }
    public void SwitchToHigh()
    {
        additionImage.texture = highAltAddition;
    }
}
