using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class TurnTracker : MonoBehaviour
{
    public List<GameObject> players;
    public GameObject CameraAnchor;
    public GameObject activeBullet;
    public float CamSpeed;
    public bool isActiveBullet;
    public bool wasActiveBullet;
    public int nextPlayer = 1;
    public int currentPlayer;
    public int Repeatable = 2;
    public bool GameStarted = false;
    public bool PlayerOneSet = false;

    private void Start()
    {
        //When the game first starts it sets the camera to the first player (made redundant) although sets the currentPlayer and next player to the appropriate values incase they get changed?
        CameraAnchor.transform.position = players[0].transform.position;
        players[0].GetComponent<PlayerActivator>().Activated = true;
        currentPlayer = 0;
        nextPlayer = 1;
    }

    private void Update()
    {
        //Once the first player has loaded it sets the camera to the current activated player.
        if (GameStarted && !PlayerOneSet)
        {
            players[0].GetComponent<PlayerActivator>().Activated = true;
            //this is to make this if statement fire once to avoid weird camera things.
            PlayerOneSet = true;
        }
        //little thing so I can personally change the players so I could bugtest. :)
        if (Input.GetKeyDown("g"))
        {
            players[currentPlayer].GetComponent<PlayerActivator>().Activated = false;
            FindNextAlivePlayer();
        }

        //this makes sure that the list repeats back to 0 when the next player doesnt exits in the list because its that last player.
        if (nextPlayer >= players.Count)
        {
            nextPlayer = 0;
        }
        //when there is an active bullet sets the camera to move towards the active bullet.
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
            //when the bullet turns false, meaning it either died or completed its mission. Activates the FindNextAlivePlayer function.
            FindNextAlivePlayer();
            //allows another bullet to be shot, resets the sequences.
            wasActiveBullet = false;
        }

        if (!isActiveBullet && !activeBullet.activeSelf)
        {
            //Sets the camera to what ever player is active.
            CameraAnchor.transform.position = Vector3.MoveTowards(CameraAnchor.transform.position,
                players[currentPlayer].transform.position, CamSpeed);
        }
    }

    void FindNextAlivePlayer()
    {
        //this if statement helps the function repeat without creating an overload (otherwise it crashes)
        if (Repeatable >= 1)
        {
            //for statement cycles from the current player to the end of the list to find the next player that hasnt been set to false.
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
                    //if this for statement makes it through the entire list and doesnt return an alive player
                    //then it sets the next player to 0 and runs the function again once but from the start of the list.
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
        //this sets the for statement back to its orginal state so it can repeat once again.
        Repeatable = 2;
        //sets the next player to the current player.
        currentPlayer = nextPlayer;
        //sets current player's PlayerActivator script to be Activated.
        players[currentPlayer].GetComponent<PlayerActivator>().Activated = true;
        //adds one to the nextPlayer int so that it checks the next player not the one we just assigned.
        nextPlayer++;
    }
}
