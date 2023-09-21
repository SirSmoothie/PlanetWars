using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float LifeSpan;
    public float Inert;
    private Rigidbody rg;
    public float Speed;
    private void Awake()
    {
        
        rg = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        LifeSpan -= Time.deltaTime;
        if (LifeSpan <= 0f)
        {
            gameObject.SetActive(false);
        }
        Inert -= Time.deltaTime;
        if (Inert <= 0f)
        {
            gameObject.GetComponent<SphereCollider>().enabled = true;
        }
        Debug.DrawRay(transform.position, transform.forward);
        //direction = transform.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Inert <= 0 && other.tag == "Destroyable")
        {
            gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        //rg.velocity = direction * Speed;
    }
}
