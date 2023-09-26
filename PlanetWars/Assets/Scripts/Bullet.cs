using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float fuelUsageRate;
    public float Inert;
    private Rigidbody rg;
    public float fuel;
    public float TurnSpeed;
    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Forward;
    public float outOfFuelTimer;
    public GameObject fuelUsageIndicator;
    private void Awake()
    {
        
        rg = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (fuel <= 0f)
        {
            outOfFuelTimer -= Time.deltaTime;
        }

        if (outOfFuelTimer <= 0)
        {
            gameObject.SetActive(false);
        }
        Inert -= Time.deltaTime;
        if (Inert <= 0f)
        {
            gameObject.GetComponent<SphereCollider>().enabled = true;
        }
        Debug.DrawRay(transform.position, transform.forward);

        if (Input.GetKey(Left))
        {
            transform.Rotate(-TurnSpeed, 0f,0f);
        }
        
        if (Input.GetKey(Right))
        {
            transform.Rotate(TurnSpeed, 0f,0f);
        }
        
        if (Input.GetKey(Forward) && fuel >= 0)
        {
            fuelUsageIndicator.SetActive(true);
            gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * fuel);
            fuel -= fuelUsageRate;
        }
        else
        {
            fuelUsageIndicator.SetActive(false);
        }
    }
    
}
