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
        //When A player is created it adds itself to the List of players on the TurnTracker script.
        turnTracker.GetComponent<TurnTracker>().players.Add(gameObject);
        //It also turns the bool GameStarted to true so it activates the TurnTracker script.
        turnTracker.GetComponent<TurnTracker>().GameStarted = true;
    }

    private void Update()
    {
        if (Activated)
        {
            //if its activates it gives the player control of the cannon/Controller.
            controller.SetActive(true);
            cannonView.GetComponent<PointTowards>().notActive = false;
        }
        else
        {
            //otherwise the child Controller is set to false.
            controller.SetActive(false);
            cannonView.GetComponent<PointTowards>().notActive = true;
        }

        if (!Alive)
        {
            //if the PlayerStatus sets the bool of this script to false it turns off the entire player.
            gameObject.SetActive(false);
        }
    }
}
