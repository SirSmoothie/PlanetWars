using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    public GameObject pointTo;
    public float floatymickfloat;
    public Bullet projectile;
    public float Speed;
    public float BulletLifeSpan;
    //public float BulletConstantSpeed; variable for old script
    public GameObject turnTracker;
    public GameObject mainBody;
    public GameObject lastShotObject;
    public KeyCode Fire;
    void Update()
    {
        //makes the gameobject look towards the pointTo gameobject (which is fixed on the mouse position on the screen).
        Vector3 targetDirection = pointTo.transform.position - gameObject.transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, floatymickfloat, 0f);
        gameObject.transform.rotation = Quaternion.LookRotation(newDirection);
        
        //when the fire key is pressed it makes a clone of the bullet prefab and sets a value for fuel and inert (see the Bullet script for details on those).
        //It also finds the Turn tracker and sets the activeBullet gameobject to the bullet that was just cloned.
        if (Input.GetKeyDown(Fire))
        {
            Bullet clone = Instantiate(projectile, transform.position, transform.rotation);
            clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * Speed);
            clone.fuel = BulletLifeSpan;
            clone.Inert = 0.5f;
            clone.GameObject().SetActive(true);
            turnTracker.GetComponent<TurnTracker>().activeBullet = clone.gameObject;
            
            //this sends the players own lastShotObject object the bool wasShot as true (see ShotLocation Script for more detail).
            lastShotObject.GetComponent<ShotLocation>().wasShot = true;
            
            //This must be the last line in sequence, otherwise It shuts off before it can finish the entire script. (like a break Function)
            mainBody.GetComponent<PlayerActivator>().Activated = false;
        }
        
        
        /*
        if (Input.GetKey(Left))
        {   
            transform.Rotate(transform.rotation.x - RotateSpeed,0,0);
        }

        if (Input.GetKey(Right))
        {
            transform.Rotate(transform.rotation.x + RotateSpeed,0,0);
        }
        if (Input.GetKeyDown(Fire))
        {
            for (int i = 0; i < BulletCountItems; i++)
            {
                Bullet clone = Instantiate(projectile, transform.position, transform.rotation);
                clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * Speed);
                clone.LifeSpan = BulletLifeSpan;
                clone.Speed = BulletConstantSpeed;
                clone.GameObject().SetActive(true);
            }
        }
        */

    }
}
