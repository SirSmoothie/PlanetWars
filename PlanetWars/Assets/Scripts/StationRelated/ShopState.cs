using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ShopState : MonoBehaviour
{
    public InsideState Inside;
    public GameObject player;
    public GameObject playerShopPos;
    public UpragdingState upragdingState;
    public float speed;
    public float test;
    public float test2;
    private void OnEnable()
    {
        upragdingState.StopUpgradingEvent += LeaveShop;
        player.transform.DOMove(new Vector3(playerShopPos.transform.position.x, playerShopPos.transform.position.y, playerShopPos.transform.position.z), speed);
        player.transform.DORotate(new Vector3(test, test2,  player.transform.rotation.z), speed);
        EnterShopEvent();
    }

    public delegate void shopWindowOn();
    public event shopWindowOn EnterShopEvent;
    
    public delegate void LeavingShop();
    public event LeavingShop leftShopEvent;
    
    
    void LeaveShop()
    {
        leftShopEvent();
        gameObject.GetComponent<StateManager>().ChangeState(Inside);
    }
    private void OnDisable()
    {
        upragdingState.StopUpgradingEvent -= LeaveShop;
    }
}
