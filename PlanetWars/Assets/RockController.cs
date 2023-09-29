using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    public Destroyable destroyable;

    public void Start()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y,0f);
    }

    private void Update()
    {
        if (destroyable.health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
