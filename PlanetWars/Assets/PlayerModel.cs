using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerModel : MonoBehaviour
{
    public float speed;
    
    public float bulletSpeed;
    public float bulletDmg;
    
    public float fireRate;
    
    public bool dashAbility;
    public float fireRange;

    public PlayerController playerController;
    public PlayerInput playerInput;
    void Start()
    {
        playerInput.actions.FindAction("Forward").performed += OnForwardOnperformed;
        playerInput.actions.FindAction("Forward").canceled += OnForwardOnperformed;
        playerInput.actions.FindAction("Interact").performed += aContext => playerController.Interact();
        playerInput.actions.FindAction("Interact").canceled += aContext => playerController.StopInteract();
        playerInput.actions.FindAction("Dash").canceled += aContext => playerController.Dash();

        playerInput.actions.FindAction("Turn").performed += OnCarTurnOnperformed;
        playerInput.actions.FindAction("Turn").canceled += OnCarTurnOnperformed;
        
        GameManager.Instance.Players.Add(gameObject);
    }
    private void OnForwardOnperformed(InputAction.CallbackContext aContext)
    {
        if (aContext.phase == InputActionPhase.Performed)
        {
            playerController.Forward();
        }
        if(aContext.phase == InputActionPhase.Canceled)
        {
            playerController.stopForward();
        }
    }
    private void OnCarTurnOnperformed(InputAction.CallbackContext aContext)
    {
        if (aContext.phase == InputActionPhase.Performed)
        {
            playerController.Turn(aContext.ReadValue<Vector2>().x);
        }
        if(aContext.phase == InputActionPhase.Canceled)
        {
            playerController.Turn(0);
        }
    }
}
