using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    public float Opening;
    public DoorOpen opened;
    public GameObject topDoor;
    public GameObject topDoorPos;
    public GameObject bottomDoor;
    public GameObject bottomDoorPos;
    public float Speed;
    private void OnEnable()
    {
        StartDoorOpening();
    }

    public void Update()
    {
        if (topDoor.transform.position.x >= 2.5f)
        {
            DoorOpened();
        }
    }

    void StartDoorOpening()
    {
        topDoor.transform.DOMove(new Vector3(bottomDoor.transform.position.x, topDoorPos.transform.position.y, bottomDoor.transform.position.z), Speed);
        bottomDoor.transform.DOMove(new Vector3(bottomDoor.transform.position.x, bottomDoorPos.transform.position.y, bottomDoor.transform.position.z), Speed);
    }

    void DoorOpened()
    {
        gameObject.GetComponent<DoorStateManager>().ChangeState(opened);
    }
    private void OnDisable()
    {
        Opening = 0;
    }
}
