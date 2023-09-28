using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    public Destroyable destroyable;

    private void Update()
    {
        if (destroyable.health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
