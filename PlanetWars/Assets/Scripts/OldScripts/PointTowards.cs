using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTowards : MonoBehaviour
{
    public GameObject pointToLast;
    public GameObject pointToCurrent;
    public float maxRadians;
    public bool notActive;
    private void Update()
    {
        if (notActive)
        {
            //sets the objects location to the gameobjects position PointToLast if the playerActivator is not active.
            Vector3 targetDirection = pointToLast.transform.position - gameObject.transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, maxRadians, 0f);
            gameObject.transform.rotation = Quaternion.LookRotation(newDirection);
        }
        else
        {
            //While the player has control of the player it sets the position of where the cannon should point to to the current mouse position.
            Vector3 targetDirection = pointToCurrent.transform.position - gameObject.transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, maxRadians, 0f);
            gameObject.transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}
