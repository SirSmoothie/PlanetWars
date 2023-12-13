using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotAliveState : MonoBehaviour
{
    public GameObject View;
    public PlayerController playerController;
    private void OnEnable()
    {
        View.SetActive(false);
        playerController.enabled = false;
        GameManager.Instance.removePlayer(playerController.PlayerIndex);
        GameManager.Instance.PlayerUpdate();
    }
}
