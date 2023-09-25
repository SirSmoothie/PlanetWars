using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActivator : MonoBehaviour
{
    public GameObject controller;
    public GameObject view;
    public bool Alive;
    public bool Activated;
    public GameObject turnTracker;

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
            view.SetActive(false);
        }
        else
        {
            view.SetActive(true);
            controller.SetActive(false);
        }

        if (!Alive)
        {
            gameObject.SetActive(false);
        }
    }
}
