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
            Vector3 targetDirection = pointToLast.transform.position - gameObject.transform.position;

            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, maxRadians, 0f);

            Debug.DrawRay(transform.position, newDirection, Color.red);
        
            gameObject.transform.rotation = Quaternion.LookRotation(newDirection);
        }
        else
        {
            Vector3 targetDirection = pointToCurrent.transform.position - gameObject.transform.position;

            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, maxRadians, 0f);

            Debug.DrawRay(transform.position, newDirection, Color.red);
        
            gameObject.transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}
