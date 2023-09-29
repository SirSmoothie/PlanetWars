using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    public float DashForce;
    public Rigidbody rb;
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
        if (Input.GetKeyDown(fire))
        {
            BulletController clone;
            clone = Instantiate(projectile, spawnLocation.transform.position, transform.rotation, bulletFolder.transform);
            clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * bulletSpeed);
            clone.dmg = bulletDmg;
            clone.strength = bulletStrength;
            clone.inert = 0;
        }

        if (Input.GetKeyDown(Dash))
        {
            rb.AddForce(transform.forward * DashForce,ForceMode.Impulse);
        }
    }
}
