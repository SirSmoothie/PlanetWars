using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class DoorStateManager : MonoBehaviour
{
    public StateBase startingState;
    public StateBase currentState;

    private void Start()
    {
        ChangeState(startingState);
    }

    public void ChangeState(StateBase newState)
    {
        if (newState == currentState)
        {
            return;
        }

        if (currentState != null)
        {
            currentState.enabled = false;
        }

        newState.enabled = true;
        currentState = newState;
    }
    
}
