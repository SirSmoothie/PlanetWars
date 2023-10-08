using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour, IPickupable
{
 public int crystalCurrency;
 public void AddCrystals(int Value)
 {
  crystalCurrency += Value;
 }
 public void Pickup(int pickupValue)
 {
  AddCrystals(pickupValue);
 }
}
