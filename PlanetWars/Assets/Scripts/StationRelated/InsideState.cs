using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideState : MonoBehaviour
{
    public outsideState outside;
    private void OnEnable()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        gameObject.GetComponent<StateManager>().ChangeState(outside);
    }

    private void OnDisable()
    {
        
    }
}
