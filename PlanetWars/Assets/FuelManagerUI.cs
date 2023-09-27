using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FuelManagerUI : MonoBehaviour
{
    public TextMeshProUGUI fuelAmount;

    public float fuel;
    public Bullet bullet;
    public bool newBullet;

    void Update()
    {
        if (newBullet)
        {
            bullet.DisplayFuelEvent += TestFunction;
        }
        else
        {
            bullet.DisplayFuelEvent -= TestFunction;
        }

        if (!bullet.gameObject.activeSelf)
        {
            newBullet = false;
        }
    }


    public void TestFunction(float f)
    {
        fuel = f;
        fuelAmount.text = fuel.ToString();
        //Debug.Log(fuel);
    }
    
    
}
