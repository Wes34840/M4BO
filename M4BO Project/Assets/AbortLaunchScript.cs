using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AbortLaunchScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    Slider abortProgress;

    // Start is called before the first frame update
    void Start()
    {
        abortProgress = GameObject.Find("AbortProgress").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        abortProgress.value += 0.1f;
    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }


}
