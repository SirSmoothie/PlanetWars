using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayingState : MonoBehaviour
{
    public PlayerController playerControls;
    public ShopState shopState;
    public UpragdingState upgradingState;

    private void OnEnable()
    {
        playerControls.enabled = true;
        shopState.EnterShopEvent += InShop;
    }

    void InShop()
    {
        gameObject.GetComponent<StateManager>().ChangeState(upgradingState);
    }
    private void OnDisable()
    {
        playerControls.enabled = false;
        shopState.EnterShopEvent -= InShop;
    }
}
