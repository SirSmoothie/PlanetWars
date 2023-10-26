using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour, IDamageable
{
    public float health;

    public void TakeDmg(float dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Damage(float damageAmount)
    {
        TakeDmg(damageAmount);
    }
    
    public delegate void KillObject();

    public event KillObject KillObjectEvent;
    private void Die()
    {
        KillObjectEvent();
    }
}
