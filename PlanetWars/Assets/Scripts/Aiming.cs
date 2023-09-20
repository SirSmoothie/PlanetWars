using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    public GameObject Mouse;
    public float floatymickfloat;
    public Bullet projectile;
    public float Speed;
    public float BulletLifeSpan;
    public float BulletConstantSpeed;
    public int BulletCountItems;
    void Update()
    {
        Vector3 targetDirection = Mouse.transform.position - gameObject.transform.position;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, floatymickfloat, 0f);

        Debug.DrawRay(transform.position, newDirection, Color.red);

        gameObject.transform.rotation = Quaternion.LookRotation(newDirection);

        if (Input.GetMouseButtonDown(0))
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

    }
}