using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketHealthSystem : MonoBehaviour
{
    internal float rocketHealth;
    private bool isDead = false;
    private LaunchHandler launchHandler;
    [SerializeField] private GameObject crashDebrisSprite;

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
            GameObject rocketDebris = Instantiate(crashDebrisSprite, transform.position, Quaternion.Euler(0, 0, Random.Range(-180, 180)));
            rocketDebris.GetComponent<Rigidbody2D>().velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
            Destroy(gameObject);
        }
    }
}
