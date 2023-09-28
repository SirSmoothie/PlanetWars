using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    public Rigidbody rb;
    public KeyCode left;
    public KeyCode right;
    public KeyCode forward;
    public KeyCode fire;
    public BulletController projectile;
    public float bulletSpeed;
    public float bulletDmg;
    public GameObject SpawnLocation;

    void Update()
    {
        if (Input.GetKey(forward))
        {
            Debug.Log("Forward!!");
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

        if (Input.GetKeyDown(fire))
        {
            BulletController clone = Instantiate(projectile, SpawnLocation.transform.position, transform.rotation);
            clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * bulletSpeed);
            clone.dmg = bulletDmg;
            clone.Inert = 0.5f;
        }
    }
}
