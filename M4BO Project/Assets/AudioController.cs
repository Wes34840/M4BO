using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public AudioSource audio;
    public UpdateBackgroundSprites altitudeChecker;
    public AudioClip highAltMusic;
    bool triggeredHighAltMusic = false;
    // Update is called once per frame
    void Update()
    {
        Debug.Log(altitudeChecker.currentStage);
        if (altitudeChecker.currentStage == Altitudes.Medium && !audio.isPlaying)
        {
            audio.Play();
        }
        if (altitudeChecker.currentStage == Altitudes.High && !triggeredHighAltMusic)
        {
            Debug.Log("HighAlt Music");
            triggeredHighAltMusic = true;
            audio.Stop();
            audio.clip = highAltMusic;
            audio.Play();
        }
    }
}
