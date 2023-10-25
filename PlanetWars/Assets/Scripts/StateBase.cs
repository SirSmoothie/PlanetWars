using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBase : MonoBehaviour
{
    public StateBase nextState;

    public void SetState(StateBase statebase)
    {
        gameObject.GetComponent<DoorStateManager>().ChangeState(statebase);
    }
    public void Change()
    {
        ChangeState(nextState);
    }

    public void ChangeState(StateBase StateToChangeToo)
    {
        nextState = StateToChangeToo;
        gameObject.GetComponent<DoorStateManager>().ChangeState(nextState);
    }
}
