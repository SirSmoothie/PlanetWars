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
    public GameObject bottomDoor;
    public float Speed;
    private void OnEnable()
    {
        
    }

    public void Update()
    {
        if (topDoor.transform.position.x >= 2.5f)
        {
            DoorOpened();
        }
        else
        {
            //topDoor.transform.DOMove(new Vector3(transform.position.x, 2.5f, transform.position.z), Speed);
            //bottomDoor.transform.DOMove(new Vector3(transform.position.x, -2.5f, transform.position.z), Speed);
        }
    }

    void DoorOpen()
    {
        
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
