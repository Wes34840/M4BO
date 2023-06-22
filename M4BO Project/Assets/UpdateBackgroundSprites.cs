using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateBackgroundSprites : MonoBehaviour
{
    public Renderer backgroundSprite, backgroundAddition;
    public Material lowAltBackground, lowAltBackgroundAdd, mediumAltBackground, mediumAltBackgroundAdd;//highAltBackground, highAltBackgroundAdd;

    public enum altitude { low, medium, high }
    public altitude currentStage;

    void Start()
    {
        currentStage = altitude.low;
        backgroundSprite.material = lowAltBackground;
        backgroundAddition.material = lowAltBackgroundAdd;
    }

    // Update is called once per frame
    void Update()
    {
        if (LaunchData.HeightReached >= (GlobalData.EndHeight / 5) && currentStage != altitude.medium)
        {
            currentStage = altitude.medium;
            ChangeBackground(mediumAltBackground, mediumAltBackgroundAdd);
        }
        //if (LaunchData.HeightReached >= (GlobalData.EndHeight / 2) && currentStage != altitude.high)
        //{
        //    currentStage = altitude.high;
        //    ChangeBackground(highAltBackground, highAltBackgroundAdd);
        //}
    }

    void ChangeBackground(Material background, Material backgroundAdd)
    { 
        backgroundSprite.material = background;
        backgroundAddition.material = backgroundAdd;
    }
}
