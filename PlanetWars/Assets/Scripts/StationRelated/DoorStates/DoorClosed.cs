using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DoorClosed : StateBase
{
    public GameObject topDoor;
    public GameObject bottomDoor;
    public GameObject doorClosedPos;
    public float Speed;

    public void OnEnable()
    {
        topDoor.transform.DOMove(new Vector3(topDoor.transform.position.x, doorClosedPos.transform.position.y, topDoor.transform.position.z), Speed);
        bottomDoor.transform.DOMove(new Vector3(bottomDoor.transform.position.x, doorClosedPos.transform.position.y, bottomDoor.transform.position.z), Speed);
    }

    void DoorOpen()
    {
        Change();
    }

    private void OnTriggerEnter(Collider other)
    {
        DoorOpen();
    }
}
