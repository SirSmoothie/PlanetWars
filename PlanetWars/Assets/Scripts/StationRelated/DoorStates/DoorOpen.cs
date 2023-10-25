using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DoorOpen : StateBase
{
    public GameObject topDoor;
    public GameObject topDoorPos;
    public GameObject bottomDoor;
    public GameObject bottomDoorPos;
    public float Speed;
    private void OnEnable()
    {
        topDoor.transform.DOMove(new Vector3(bottomDoor.transform.position.x, topDoorPos.transform.position.y, bottomDoor.transform.position.z), Speed);
        bottomDoor.transform.DOMove(new Vector3(bottomDoor.transform.position.x, bottomDoorPos.transform.position.y, bottomDoor.transform.position.z), Speed);
    }

    void DoorClosed()
    {
        Change();
    }
    private void OnTriggerExit(Collider other)
    {
        DoorClosed();
    }
}
