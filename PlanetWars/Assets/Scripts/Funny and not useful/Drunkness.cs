using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drunkness : MonoBehaviour
{
    public KeyCode DrunkCam;
    public bool drunkToggle;
    public bool masterToggle;
    public float flickerRate;
    public Camera cam;

    IEnumerator DrunkVision()
    {
        Debug.Log("playing drunk");
        cam.clearFlags = CameraClearFlags.Nothing;
        yield return new WaitForSeconds(flickerRate);
        cam.clearFlags = CameraClearFlags.Color;
        yield return new WaitForSeconds(flickerRate);
        drunkToggle = true;
    }

    private void Update()
    {
        if (Input.GetKey(DrunkCam))
        {
            masterToggle = true;
        }
        if (drunkToggle && masterToggle)
        {
            drunkToggle = false;
            StartCoroutine(DrunkVision());
        }
    }
}
