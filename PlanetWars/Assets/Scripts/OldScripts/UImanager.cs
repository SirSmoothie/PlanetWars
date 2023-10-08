using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    public int ValuefromBullet;
    public EventBullet bullet;
    public TextMeshProUGUI test;
    
    public void OnEnable()
    {
        // Subscribe
        bullet.DeadEvent += TestFunction;
    }

    public void OnDisable()
    {
        // Unsubscribe
        bullet.DeadEvent -= TestFunction;
    }

    public void TestFunction(int v)
    {
        ValuefromBullet = v;
        test.text = v.ToString();
    }

}
