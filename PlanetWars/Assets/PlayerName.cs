using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerName : MonoBehaviour
{
    public PlayerController playerController;
    public int playerIndex;

    private TextMeshProUGUI text;
    private void Start()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
        playerIndex = playerController.PlayerIndex + 1;
        text.text = "Player " + playerIndex;
    }
    
    
}
