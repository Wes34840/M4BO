using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateBackgroundSprites : MonoBehaviour
{
    public Altitudes currentStage;
    public Animator animBackground, animAdd, animAudio, animWarning;
    void Start()
    {
        currentStage = Altitudes.Low;
    }

    // Update is called once per frame
    void Update()
    {
        if (LaunchData.HeightReached >= (GlobalData.EndHeight / 5) && currentStage != Altitudes.Medium )
        {
            currentStage = Altitudes.Medium;
            animBackground.SetBool("GoToMedium", true);
            animAdd.SetBool("GoToMedium", true);
            animAudio.SetBool("reachedMedium", true);

        }
        if (LaunchData.HeightReached >= (GlobalData.EndHeight / 2) && currentStage != Altitudes.High)
        {
            currentStage = Altitudes.High;
            animBackground.SetBool("GoToHigh", true);
            animAdd.SetBool("GoToHigh", true);
            animAudio.SetBool("reachedHigh", true);
            animWarning.SetBool("reachedHigh", true);
        }
    }

}
