using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public GameObject parent;
    private void OnTriggerEnter(Collider other)
    {
        //if the collider that hit the players space station collider is sets the players parent with the playerActivator script's bool Alive false.
        //this turns off the entire player.
        if (other.gameObject.tag == "Bullet")
        {
            parent.GetComponent<PlayerActivator>().Alive = false;
        }
    }
}
