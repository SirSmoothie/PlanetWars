using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DoorClosing : MonoBehaviour
{
    public float closing;
    public DoorClosed closed;
    public GameObject topDoor;
    public GameObject topDoorPos;
    public GameObject bottomDoor;
    public GameObject bottomDoorPos;
    public float Speed;
    private void OnEnable()
    {
        StartDoorClosing();
    }

    private void Update()
    {
        if (topDoor.transform.position.x <= 0)
        {
            DoorClosed();
        }
    }

    void StartDoorClosing()
    {
        topDoor.transform.DOMove(new Vector3(bottomDoor.transform.position.x, transform.position.y, bottomDoor.transform.position.z), Speed);
        bottomDoor.transform.DOMove(new Vector3(bottomDoor.transform.position.x, transform.position.y, bottomDoor.transform.position.z), Speed);
    }
    void DoorClosed()
    {
        gameObject.GetComponent<DoorStateManager>().ChangeState(closed);
    }
    private void OnDisable()
    {
        closing = 0;
    }
}
