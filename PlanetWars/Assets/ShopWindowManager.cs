using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopWindowManager : MonoBehaviour
{
    public ShopState shopState;
    public GameObject shopWindow;

    private void OnEnable()
    {
        shopState.EnterShopEvent += TurnWindowOn;
        shopState.leftShopEvent += TurnWindowOff;
    }

    public void TurnWindowOn()
    {
        shopWindow.SetActive(true);
    }
    
    public void TurnWindowOff()
    {
        shopWindow.SetActive(false);
    }

    private void OnDisable()
    {
        shopState.EnterShopEvent -= TurnWindowOn;
        shopState.leftShopEvent -= TurnWindowOff;
    }
}
