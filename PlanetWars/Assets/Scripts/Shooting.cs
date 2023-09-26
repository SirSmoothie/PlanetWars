using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float offset = 3f;
    public Vector3 Mousepos;
    void Update()
    {
        //finds the position of the mouse
        Mousepos = Input.mousePosition;
        //changes the value of the z mouse position to the offset. This needs to be changed according to the distance of the camera.
        Mousepos.z = offset;
        //uses the ScreenToWorldPoint function to find out where the mouse is in the world position and not the canvas.
        transform.position = Camera.main.ScreenToWorldPoint(Mousepos);
    }
}
