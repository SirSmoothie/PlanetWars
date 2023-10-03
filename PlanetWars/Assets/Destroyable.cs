using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour, IDamageable
{
    public float health;

    public void TakeDmg(float dmg)
    {
        health -= dmg;
    }

    public void Damage(float damageAmount)
    {
        TakeDmg(damageAmount);
    }
}
