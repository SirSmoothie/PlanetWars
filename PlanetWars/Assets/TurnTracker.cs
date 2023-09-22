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
    public GameObject activeBullet;
    public float CamSpeed;
    public bool isActiveBullet;
    public bool wasActiveBullet;
    public int playerCount;
    public int nextPlayer = 1;
    public int currentPlayer;
    public int Repeatable = 2;

    private void Start()
    {
        CameraAnchor.transform.position = players[0].transform.position;
        players[0].GetComponent<PlayerActivator>().Activated = true;
        currentPlayer = 0;
        nextPlayer = 1;
    }

    private void Update()
    {
        
        if (Input.GetKeyDown("g"))
        {
            players[currentPlayer].GetComponent<PlayerActivator>().Activated = false;
            FindNextAlivePlayer();
        }

        if (nextPlayer >= players.Count)
        {
            nextPlayer = 0;
        }
        if (activeBullet.activeSelf)
        {
            isActiveBullet = true;
            wasActiveBullet = true;
        }
        else
        {
            isActiveBullet = false;
        }
        if (isActiveBullet)
        {
            CameraAnchor.transform.position = Vector3.MoveTowards(CameraAnchor.transform.position,
                activeBullet.transform.position, CamSpeed);
        }
        else if(wasActiveBullet)
        {
            FindNextAlivePlayer();
            wasActiveBullet = false;
        }

        if (!isActiveBullet && !activeBullet.activeSelf)
        {
            CameraAnchor.transform.position = Vector3.MoveTowards(CameraAnchor.transform.position,
                players[currentPlayer].transform.position, CamSpeed);
        }
    }

    void FindNextAlivePlayer()
    {
        if (Repeatable >= 1)
        {
            for (int i = nextPlayer; i < players.Count; i++)
            {
                if (players[i].activeSelf && i < players.Count)
                {
                    nextPlayer = i;
                    NextPlayersTurn();
                    break;
                    
                }
                if(!players[i].activeSelf && i == players.Count -1)
                {
                    Repeatable--;
                    nextPlayer = 0;
                    FindNextAlivePlayer();
                }
            }
        }
        /*
        for (int i = nextPlayer; i < players.Count; i++)
        {
            if (players[i].activeSelf && i < players.Count)
            {
                nextPlayer = i + 1;
                NextPlayersTurn();
                break;
            }

            if (i == players.Count && players[i].activeSelf == false)
            {
                nextPlayer = 0;
                NextPlayersTurn();
            }
        }
        */
    }
    void NextPlayersTurn()
    {
        /*
        if (players[turnCounter].activeSelf == false)
        {
            //FindNextAlivePlayer();
        }
        else
        {
            turnCounter++;
            if (turnCounter >= players.Count)
            {
                turnCounter = 0;
                players[0].GetComponent<PlayerActivator>().Activated = true;
            }
            else if (players[turnCounter].activeSelf == false)
            {
                FindNextAlivePlayer();
            }
            else
            {
                players[turnCounter].GetComponent<PlayerActivator>().Activated = true;
            }
        }
        */
        Repeatable = 2;
        currentPlayer = nextPlayer;
        players[currentPlayer].GetComponent<PlayerActivator>().Activated = true;
        nextPlayer++;
    }
}
