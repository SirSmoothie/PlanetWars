using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WinningPlayerUI : MonoBehaviour
{
    public TextMeshProUGUI Texts;
    public TextMeshProUGUI ScoreText;
    public GameObject WinningView;
    public GameObject StartingView;
    public GameObject fadeView;
    

    public void DisplayWinner(int WinnerNo, float Score)
    {
        WinningView.SetActive(true);
        StartingView.SetActive(false);
        fadeView.SetActive(true);
        Texts.text = "Player " + WinnerNo + " Has Won The Game.";
        ScoreText.text = "Player " + WinnerNo + " Collected: " + Score + " Crystals";
    }

    public void StartGame()
    {
        StartingView.SetActive(false);
        fadeView.SetActive(false);
        WinningView.SetActive(false);
    }
    private void OnEnable()
    {
        GameManager.Instance.GameStartEvent += StartGame;
    }

    private void OnDisable()
    {
        GameManager.Instance.GameStartEvent -= StartGame;
    }
}
