using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float LifeSpan;
    public float Inert;
    private Rigidbody rg;
    public float Speed;
    public Vector3 direction;
    private void Awake()
    {
        
        rg = gameObject.GetComponent<Rigidbody>();
        Destroy(gameObject, LifeSpan);
    }

    void Update()
    {
        Inert += Time.deltaTime;
        Debug.DrawRay(transform.position, transform.forward);
        //direction = transform.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Destroyable" && Inert >= 1)
        {
            other.gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        //rg.velocity = direction * Speed;
    }
}
