using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    private Transform Target;

    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.Find("Rocket").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Target.position.y >= transform.position.y)
        {
            transform.position = new Vector3(Target.position.x, Target.position.y, -10f);
        }
    }
}
