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
    
    public KeyCode left;
    public KeyCode right;
    public KeyCode forward;
    public KeyCode fire;
    public KeyCode dash;
    
    public BulletController projectile;
    public GameObject spawnLocation;
    public GameObject bulletFolder;
    private Quaternion NoRotation;
    
    public float dashCooldown;
    public float dashCooldownMax;
    
    private bool currentFire;


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
        Destroy(gameObject);
    }

    private void OnDisable()
    {
        destroyable.KillObjectEvent -= destroy;
    }

    void Update()
    {
        
        if (Input.GetKey(forward))
        {
            Forward(playerModel.speed);
        }

        if (Input.GetKey(left))
        {
           Turn(-playerModel.turnSpeed);
        }

        if (Input.GetKey(right))
        {
            Turn(playerModel.turnSpeed);
        }
        if (Input.GetKey(fire) && !currentFire)
        {
            currentFire = true;
            StartCoroutine(Fire());
        }
        if (Input.GetKeyDown(dash) && dashCooldown <= 0 && playerModel.dashAbility)
        {
            Dash(playerModel.DashForce);
            dashCooldown = dashCooldownMax;
        }
        else if(dashCooldown >= 0.01)
        {
            dashCooldown -= Time.deltaTime;
        }
        else
        {
            dashCooldown = 0;
        }
    }
    public void Forward(float speed)
    {
        rb.AddForce(transform.forward * speed,ForceMode.Acceleration);
    }

    public void Turn(float Direction)
    {
        transform.Rotate(Direction, 0f, 0f);
    }

    public void Dash(float DashForce)
    {
        rb.AddForce(transform.forward * DashForce,ForceMode.Impulse);
    }
    
    IEnumerator Fire()
    {
        BulletController clone;
        clone = Instantiate(projectile, spawnLocation.transform.position, transform.rotation, bulletFolder.transform);
        clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * playerModel.bulletSpeed);
        clone.dmg = playerModel.bulletDmg;
        clone.inert = 0;
        clone.bulletRange = playerModel.fireRange;
        yield return new WaitForSeconds(playerModel.fireRate);
        currentFire = false;
    }
}
