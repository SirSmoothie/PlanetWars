using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class TurnTracker : MonoBehaviour
{
    public List<GameObject> players;
    public int turnCounter;
    public GameObject CameraAnchor;

    private void Start()
    {
        CameraAnchor.transform.position = players[0].transform.position;
        players[0].GetComponent<PlayerActivator>().Activated = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown("g"))
        {
            players[turnCounter].GetComponent<PlayerActivator>().Activated = false;
            NextPlayersTurn();
        }
        if (turnCounter >= players.Count)
        {
            NextPlayersTurn();
        }
    }

    void NextPlayersTurn()
    {
        if (players[turnCounter] == null)
        {
            players.RemoveAt(turnCounter);
            CameraAnchor.transform.position = players[turnCounter].transform.position;
            players[turnCounter].GetComponent<PlayerActivator>().Activated = true;
        }
        else
        {
            turnCounter++;
            if (turnCounter >= players.Count)
            {
                turnCounter = 0;
                CameraAnchor.transform.position = players[0].transform.position;
                players[0].GetComponent<PlayerActivator>().Activated = true;
            }
            else if (players[turnCounter] == null)
            {
                players.RemoveAt(turnCounter);
                CameraAnchor.transform.position = players[turnCounter].transform.position;
                players[turnCounter].GetComponent<PlayerActivator>().Activated = true;
            }
            else
            {
                CameraAnchor.transform.position = players[turnCounter].transform.position;
                players[turnCounter].GetComponent<PlayerActivator>().Activated = true;
            }
        }
    }
}
