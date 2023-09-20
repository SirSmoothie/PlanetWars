using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float LifeSpan;
    private Rigidbody rg;
    public float Speed;
    public Vector3 Pos;
    private void Awake()
    {
        
        rg = gameObject.GetComponent<Rigidbody>();
            Destroy(gameObject, LifeSpan);
    }

    void Update()
    {
        rg.AddForce(Vector3.forward * Speed);
    }

}
