using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    public float DashForce;
    private Rigidbody rb;
    public KeyCode left;
    public KeyCode right;
    public KeyCode forward;
    public KeyCode fire;
    public KeyCode Dash;
    public BulletController projectile;
    public float bulletSpeed;
    public float bulletDmg;
    public float bulletStrength;
    public GameObject spawnLocation;
    public GameObject bulletFolder;
    private Quaternion NoRotation;
    public float dashCooldown;
    public float dashCooldownMax;
    public bool dashAbility;
    public float fireRate;
    private bool currentFire;


    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(forward))
        {
            //Debug.Log("Forward!!");
            rb.AddForce(transform.forward * speed,ForceMode.Acceleration);
        }

        if (Input.GetKey(left))
        {
            transform.Rotate(-turnSpeed, 0f, 0f);
        }

        if (Input.GetKey(right))
        {
            transform.Rotate(turnSpeed, 0f, 0f);
        }

        if (!Input.GetKey(left) && !Input.GetKey(right))
        {
            transform.Rotate(0f, 0f, 0f);
        }
        if (Input.GetKey(fire) && !currentFire)
        {
            currentFire = true;
            StartCoroutine(Fire());
        }
        if (Input.GetKeyUp(fire) && !currentFire)
        {
            currentFire = false;
        }

        if (Input.GetKeyDown(Dash) && dashCooldown <= 0 && dashAbility)
        {
            rb.AddForce(transform.forward * DashForce,ForceMode.Impulse);
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
    
    IEnumerator Fire()
    {
        BulletController clone;
        clone = Instantiate(projectile, spawnLocation.transform.position, transform.rotation, bulletFolder.transform);
        clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * bulletSpeed);
        clone.dmg = bulletDmg;
        clone.inert = 0;
        yield return new WaitForSeconds(fireRate);
        currentFire = false;
    }
}
