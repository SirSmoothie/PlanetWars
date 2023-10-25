using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DoorClosing : StateBase
{
    public GameObject topDoor;
    public GameObject bottomDoor;
    public GameObject doorClosedPos;
    public float Speed;
    private void OnEnable()
    {
        StartDoorClosing();
    }

    public void Update()
    {
        if (topDoor.transform.position.y == doorClosedPos.transform.position.y)
        {
            DoorClosed();
        }
    }

    void StartDoorClosing()
    {
        topDoor.transform.DOMove(new Vector3(topDoor.transform.position.x, doorClosedPos.transform.position.y, topDoor.transform.position.z), Speed);
        bottomDoor.transform.DOMove(new Vector3(bottomDoor.transform.position.x, doorClosedPos.transform.position.y, bottomDoor.transform.position.z), Speed);
    }
    void DoorClosed()
    {
        Change();
    }
}
