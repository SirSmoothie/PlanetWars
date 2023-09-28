using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FuelManagerUI : MonoBehaviour
{
    public TextMeshProUGUI fuelAmount;
    public Slider fuelGuage;
    public float fuelMax;

    public float fuel;
    public Bullet bullet;
    public bool newBullet;

    void Update()
    {
        
        if (newBullet)
        {
            bullet.DisplayFuelEvent += TestFunction;
        }
        if(!newBullet)
        {
            bullet.DisplayFuelEvent -= TestFunction;
        }

        if (!bullet.gameObject.activeSelf)
        {
            newBullet = false;
        }
            
        
    }


    public void TestFunction(float f, float fM)
    {
            fuel = f;
            fuelMax = fM;
            fuelGuage.maxValue = fuelMax;
            fuelGuage.value = fuel; 
            fuelAmount.text = fuel.ToString();
            //Debug.Log(fuel);
    }
    
    
}
