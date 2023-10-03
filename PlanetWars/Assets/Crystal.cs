using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    public int crystalValue;
    private void OnTriggerEnter(Collider other)
    {
        IPickupable pickupable = other.transform.GetComponent<IPickupable>();
        if (pickupable != null)
        {
            pickupable.Pickup(crystalValue);
        }
    }
}
