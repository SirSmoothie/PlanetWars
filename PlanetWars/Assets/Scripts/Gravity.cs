using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float GravityForce;
    private void Update()
    {
        foreach (var rigidybody1 in FindObjectsByType<Rigidbody>(FindObjectsInactive.Exclude, FindObjectsSortMode.None))
        {
            rigidybody1.AddForce(transform.position - rigidybody1.transform.position * GravityForce);
        }
    }
}
