using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    public float health;
    public float armour;

    public void TakeDmg(float dmg, float strength)
    {
        if (strength > armour || strength == armour)
        {
            health -= dmg;
        }
    }
}
