using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float fuelUsageRate;
    public float Inert;
    public float fuel = 1;
    private float fuelMax;
    private float rocketForce = 10;
    public float TurnSpeed;
    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Forward;
    public float outOfFuelTimer;
    public GameObject fuelUsageIndicator;

    private void OnEnable()
    {
        fuelMax = fuel;
    }

    void Update()
    {
        //starts timer when fuel reaches 0 or below.
        if (fuel <= 0f)
        {
            outOfFuelTimer -= Time.deltaTime;
        }
        
        //When the timer above reaches 0 or below is sets the bullet active status to false.
        if (outOfFuelTimer <= 0)
        {
            gameObject.SetActive(false);
        }
        
        //stops the collider from being active for a certain amount of time, collider kept destroying the space station it was shot from. (I did it like this so you rocket can still kill you)
        Inert -= Time.deltaTime;
        if (Inert <= 0f)
        {
            gameObject.GetComponent<SphereCollider>().enabled = true;
        }
        
        //Left and Right if's rotate the player on the x axis by a positive and negative number to mimic turning.
        if (Input.GetKey(Left))
        {
            transform.Rotate(-TurnSpeed, 0f,0f);
        }
        if (Input.GetKey(Right))
        {
            transform.Rotate(TurnSpeed, 0f,0f);
        }
        
        //When the Forward Key is pushed down it consumes fuel and adds force to where ever its facing, also consumes fuel based off a fixed rate.
        if (Input.GetKey(Forward) && fuel >= 0)
        {
            fuelUsageIndicator.SetActive(true);
            gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * rocketForce);
            fuel -= fuelUsageRate;
        }
        else
        {
            //turns off a gameobject so players know they are using fuel.
            fuelUsageIndicator.SetActive(false);
        }
        
        DisplayFuel();
    }
    
    
    public delegate void FuelDelegate(float f, float fM);

    public event FuelDelegate DisplayFuelEvent;

    public void DisplayFuel()
    {
        DisplayFuelEvent?.Invoke(fuel, fuelMax);
    }
    
}
