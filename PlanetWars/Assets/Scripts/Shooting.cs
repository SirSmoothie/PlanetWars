using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float offset = 3f;
    public Vector3 Mousepos;
    void Update()
    {
        Mousepos = Input.mousePosition;
        Mousepos.z = offset;
        transform.position = Camera.main.ScreenToWorldPoint(Mousepos);
    }
}
