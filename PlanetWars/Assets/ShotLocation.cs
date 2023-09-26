using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotLocation : MonoBehaviour
{
    public float offset = 3f;
    public Vector3 Mousepos;
    public bool wasShot;
    public bool waitingToShoot;
    void Update()
    {
        if (wasShot)
        {
            Mousepos = Input.mousePosition;
            Mousepos.z = offset;
            transform.position = Camera.main.ScreenToWorldPoint(Mousepos);
            wasShot = false;
        }
        if (waitingToShoot)
        {
            Mousepos = Input.mousePosition;
            Mousepos.z = offset;
            transform.position = Camera.main.ScreenToWorldPoint(Mousepos);
        }
    }
}
