using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float dmg;
    public float strength;
    public float inert = 1;
    public Destroyable destroyable;
    private void OnCollisionEnter(Collision other)
    {
        other.gameObject.GetComponent<Destroyable>().TakeDmg(dmg, strength);
        destroyable.TakeDmg(dmg, strength);
    }

    private void Update()
    {
        if (destroyable.health <= 0)
        {
            Destroy(gameObject);
        }

        inert -= Time.deltaTime;
        if (inert <= 0)
        {
            gameObject.GetComponent<Collider>().enabled = true;
        }
    }
}
