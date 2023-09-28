using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    public float health;
    public float armour;
    private float finDmg;

    public void TakeDmg(float dmg)
    {
        finDmg = dmg - armour;
        health -= finDmg;
    }
}
