using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDisable : MonoBehaviour
{
 public PlayerAbilities playerAbilites;
 public Button button;
 private void OnEnable()
 {
  playerAbilites.DashBoughtEvent += DisableButton;
 }

 public void DisableButton()
 {
  button.interactable = false;
 }
 private void OnDisable()
 {
  playerAbilites.DashBoughtEvent -= DisableButton;
 }
}
