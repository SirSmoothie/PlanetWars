using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpragdingState : MonoBehaviour
{
    public PlayingState playingState;
    public ButtonEvent buttonEvent;
    
    private void OnEnable()
    {
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        buttonEvent.ButtonPressedEvent += LeaveShop;
    }

    public delegate void StopUprading();

    public event StopUprading StopUpgradingEvent;
    void LeaveShop()
    {
        StopUpgradingEvent();
        gameObject.GetComponent<StateManager>().ChangeState(playingState);
    }
    private void OnDisable()
    {
        buttonEvent.ButtonPressedEvent -= LeaveShop;
    }
}
