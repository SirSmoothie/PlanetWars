using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float dmg;
    public float inert = 1;
    public bool hasHitSmth = false;
    public float bulletRange;
    private void OnCollisionEnter(Collision other)
    {
        IDamageable damageable = other.transform.GetComponent<IDamageable>();
        if (damageable != null && !hasHitSmth)
        {
            damageable.Damage(dmg);
            hasHitSmth = true;
            
        }
        Destroy(gameObject);
    }

    private void Awake()
    {
        Destroy(gameObject, bulletRange);
    }
    private void Update()
    {
        inert -= Time.deltaTime;
        if (inert <= 0)
        {
            gameObject.GetComponent<Collider>().enabled = true;
        }
    }
}
