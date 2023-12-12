using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject player1;
    public GameObject player2;

    public List<GameObject> Players;

    public delegate void Player1Died();
    public event Player1Died Player2WinsEvent;

    public void Player2Victory()
    {
        Player2WinsEvent?.Invoke();
    }
    public delegate void Player2Died();
    public event Player2Died Player1WinsEvent;
    public void Player1Victory()
    {
        Player1WinsEvent?.Invoke();
    }

    private void Update()
    {
        if (Players.Count <= 1)
        {
            
        }
    }

    protected override void Initialize()
    {
        
    }
}
