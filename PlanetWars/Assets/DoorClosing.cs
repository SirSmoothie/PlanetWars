using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DoorClosing : MonoBehaviour
{
    public float closing;
    public DoorClosed closed;
    public GameObject topDoor;
    public GameObject bottomDoor;
    public float Speed;
    private void OnEnable()
    {
        
    }

    private void Update()
    {
        if (topDoor.transform.position.x <= 0)
        {
            DoorClosed();
        }
        else
        {
            topDoor.transform.DOMove(new Vector3(transform.position.x, 0, transform.position.z), Speed);
            bottomDoor.transform.DOMove(new Vector3(transform.position.x, 0, transform.position.z), Speed);
        }
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
