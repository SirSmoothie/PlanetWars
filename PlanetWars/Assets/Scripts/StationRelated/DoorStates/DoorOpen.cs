using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public DoorClosing closing;
    private void OnEnable()
    {
        
    }

    private void Update()
    {

    }

    void DoorClosed()
    {
        gameObject.GetComponent<DoorStateManager>().ChangeState(closing);
    }
    private void OnDisable()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        DoorClosed();
    }
}
