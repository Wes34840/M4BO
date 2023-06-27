using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateBackgroundSprites : MonoBehaviour
{
    public RawImage backgroundSprite, backgroundAddition;
    public Texture2D lowAltBackground, lowAltBackgroundAdd, mediumAltBackground, mediumAltBackgroundAdd, highAltBackground, highAltBackgroundAdd;

    public Altitudes currentStage;

    void Start()
    {
        currentStage = Altitudes.Low;
        backgroundSprite.texture = lowAltBackground;
        backgroundAddition.texture = lowAltBackgroundAdd;
    }

    // Update is called once per frame
    void Update()
    {
        if (LaunchData.HeightReached >= (GlobalData.EndHeight / 5) && currentStage != Altitudes.Medium)
        {
            currentStage = Altitudes.Medium;
            ChangeBackground(mediumAltBackground, mediumAltBackgroundAdd);
        }
        if (LaunchData.HeightReached >= (GlobalData.EndHeight / 2) && currentStage != Altitudes.High)
        {
            currentStage = Altitudes.High;
            ChangeBackground(highAltBackground, highAltBackgroundAdd);
        }
    }

    void ChangeBackground(Texture2D background, Texture2D backgroundAdd)
    { 
        backgroundSprite.texture = background;
        backgroundAddition.texture = backgroundAdd;
    }
}
