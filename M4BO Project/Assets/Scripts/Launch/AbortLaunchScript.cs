using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AbortLaunchScript : MonoBehaviour
{

    Slider abortProgress;
    Image fill;
    public bool isPressed = false;
    LaunchHandler handler;
    

    void Start()
    {
        abortProgress = GameObject.Find("AbortProgress").GetComponent<Slider>();
        fill = GameObject.Find("AbortFill").GetComponent<Image>();
        handler = GameObject.Find("Game Handler").GetComponent<LaunchHandler>();
    }

    void Update()
    {
        if (isPressed)
        {
            UpdateFillAlpha(0.3f);
            abortProgress.value += Time.deltaTime;
        }

        else if (!isPressed)
        {
            UpdateFillAlpha(0);
            abortProgress.value = 0f;
        }
        
        if (abortProgress.value == abortProgress.maxValue)
        {
            handler.EndLaunch();
        }
    }
    public void onPointerDownButton()
    {
        isPressed = true;
    }
    public void onPointerUpButton()
    {
        isPressed = false;
    }

    void UpdateFillAlpha(float alpha)
    {
        var TransparentColor = fill.color;
        TransparentColor.a = alpha;
        fill.color = TransparentColor;
    }

}
