using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClosed : MonoBehaviour
{
    public DoorOpening opening;
    private void OnEnable()
    {
        
    }
    void DoorOpen()
    {
        gameObject.GetComponent<DoorStateManager>().ChangeState(opening);
    }
    private void OnDisable()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        DoorOpen();
    }
}
