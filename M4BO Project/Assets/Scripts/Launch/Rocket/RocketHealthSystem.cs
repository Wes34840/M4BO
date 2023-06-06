using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketHealthSystem : MonoBehaviour
{
    internal float rocketHealth;
    private bool isDead = false;
    private LaunchHandler launchHandler;

    private void Start()
    {
        launchHandler = GameObject.Find("Game Handler").GetComponent<LaunchHandler>();
        rocketHealth = GlobalData.MaxHealth;
    }
    private void Update()
    {
        if (rocketHealth <= 0 && isDead == false)
        {
            isDead = true;
            launchHandler.EndLaunch();
            Destroy(gameObject);
        }
    }
}
