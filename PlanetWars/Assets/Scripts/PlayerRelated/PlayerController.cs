 using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public PlayerModel playerModel;
    public Destroyable destroyable;
    
    public BulletController projectile;
    public GameObject spawnLocation;
    private Quaternion NoRotation;

    public NotAliveState notAliveState;
    public Transform ParentTransform;
    public float dashCooldown;
    public float dashCooldownMax = 5;
    public float fireCooldown;
    public float fireCooldownMax = 5;
    public bool fireActive;
    
    private bool currentFire;

    private float TurnDirection;

    public float turnSpeed;
    public float dashForce;
    public float speed;
    public float bulletSpeed;
    
    private bool forward;
    private void Start()
    {
       rb = gameObject.GetComponent<Rigidbody>();
       playerModel = gameObject.GetComponent<PlayerModel>();
       destroyable = gameObject.GetComponent<Destroyable>();
    }

    private void OnEnable()
    {
        destroyable.KillObjectEvent += destroy;
    }

    void destroy()
    {
        GetComponent<StateManager>().ChangeState(notAliveState);
    }

    private void OnDisable()
    {
        destroyable.KillObjectEvent -= destroy;
    }
    public void Interact()
    {
        if (!currentFire)
        {
            fireActive = true;
        }
    }

    public void StopInteract()
    {
        if (currentFire)
        {
            Debug.Log("stopped");
            //currentFire = false;
            
        }
        fireActive = false;
    }
    
    void FixedUpdate()
    {
        if(dashCooldown >= 0.01)
        {
            dashCooldown -= Time.deltaTime;
        }
        else
        {
            dashCooldown = 0;
        }
        transform.Rotate(TurnDirection * turnSpeed, 0f, 0f);
        if (forward)
        {
            rb.AddForce(transform.forward * speed,ForceMode.Acceleration);
        }

        fireCooldown -= Time.deltaTime;
        if (fireActive)
        {

            if (fireCooldown < 0)
            {
                BulletController clone;
                clone = Instantiate(projectile, spawnLocation.transform.position, transform.rotation);
                clone.GetComponent<Rigidbody>().velocity = 
                    transform.TransformDirection(Vector3.forward * bulletSpeed);
                clone.dmg = playerModel.bulletDmg;
                clone.inert = 0;
                clone.bulletRange = playerModel.fireRange;

                fireCooldown = fireCooldownMax;
            }
        }
    }
    public void Forward()
    {
        forward = true;
    }
    
    public void stopForward()
    {
        forward = false;
    }

    public void Turn(float Direction)
    {
        TurnDirection = Direction;
    }

    public void Dash()
    {
        if (dashCooldown <= 0)
        {
            rb.AddForce(transform.forward * dashForce,ForceMode.Impulse);
            dashCooldown = dashCooldownMax;
        }
        
    }
    
    //IEnumerator Fire()
    //{
    //    BulletController clone;
    //    clone = Instantiate(projectile, spawnLocation.transform.position, transform.rotation, bulletFolder.transform);
    //    clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * playerModel.bulletSpeed);
    //    clone.dmg = playerModel.bulletDmg;
    //    clone.inert = 0;
    //    clone.bulletRange = playerModel.fireRange;
    //    yield return new WaitForSeconds(playerModel.fireRate);
    //    currentFire = false;
    //}
}
