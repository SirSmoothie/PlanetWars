using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnchor : MonoBehaviour
{
    public GameObject camAnchor;
    public void Update()
    {
        gameObject.transform.position = camAnchor.transform.position;
    }
}
