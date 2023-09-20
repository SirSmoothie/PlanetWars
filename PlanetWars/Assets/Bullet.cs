using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float LifeSpan;
    private void Awake()
    {
            Destroy(gameObject, LifeSpan);
    }
}
