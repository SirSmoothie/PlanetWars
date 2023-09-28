using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float dmg;
    public float Inert = 1;
    public Destroyable destroyable;
    private void OnCollisionEnter(Collision other)
    {
        other.gameObject.GetComponent<Destroyable>().TakeDmg(dmg);
        destroyable.TakeDmg(dmg);
    }

    private void Update()
    {
        if (destroyable.health <= 0)
        {
            Destroy(gameObject);
        }

        Inert -= Time.deltaTime;
        if (Inert <= 0)
        {
            gameObject.GetComponent<Collider>().enabled = true;
        }
    }
}
