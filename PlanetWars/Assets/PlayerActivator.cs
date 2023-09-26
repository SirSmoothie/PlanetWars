using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActivator : MonoBehaviour
{
    public GameObject controller;
    public bool Alive;
    public bool Activated;
    public GameObject turnTracker;
    public GameObject cannonView;

    private void Start()
    {
        turnTracker.GetComponent<TurnTracker>().players.Add(gameObject);
        turnTracker.GetComponent<TurnTracker>().GameStarted = true;
    }

    private void Update()
    {
        if (Activated)
        {
            controller.SetActive(true);
            cannonView.GetComponent<PointTowards>().notActive = false;
        }
        else
        {
            controller.SetActive(false);
            cannonView.GetComponent<PointTowards>().notActive = true;
        }

        if (!Alive)
        {
            gameObject.SetActive(false);
        }
    }
}
