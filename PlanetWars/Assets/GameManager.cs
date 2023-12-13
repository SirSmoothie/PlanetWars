using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public GameObject player1;
    public GameObject player2;
    
    public List<GameObject> Players;
    public List<GameObject> AllThePlayers;

    public int countOfAlivePlayers;
    public GameObject UI;
    private bool GameStarted;
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
    
    public delegate void GameStart();
    public event GameStart GameStartEvent;
    public void StartGame()
    {
        GameStartEvent?.Invoke();
        AllThePlayers = Players;
        countOfAlivePlayers = Players.Count;
    }

    public void PlayerUpdate()
    {
        for (int i = 0; i < AllThePlayers.Count; i++)
        {
            countOfAlivePlayers = AllThePlayers.Count;
            if (Players[i] == null)
            {
                countOfAlivePlayers--;
            }

            if (countOfAlivePlayers <= 1)
            {
                var index = 0;
                var score = 0;
                for (int indexOfPlayer = 0; index < AllThePlayers.Count; index++)
                {
                    if (Players[indexOfPlayer].GetComponent<PlayerController>())
                    {
                        index = Players[indexOfPlayer].GetComponent<PlayerController>().PlayerIndex;
                        score = Players[indexOfPlayer].GetComponent<PlayerInventory>().crystalCurrency;
                    }
                }
                
                
                    UI.gameObject.GetComponent<WinningPlayerUI>()?.DisplayWinner(index, score);
                    StartCoroutine(WaitToRestart());
            }
        }
    }

    IEnumerator WaitToRestart()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("NewMain", LoadSceneMode.Single);
    }
    public void removePlayer(int index)
    {
        Players.RemoveAt(index);
    }

    protected override void Initialize()
    {
        
    }
}
