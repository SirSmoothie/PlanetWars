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
    void Update()
    {
        Vector3 targetDirection = Mouse.transform.position - gameObject.transform.position;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, floatymickfloat, 0f);

        Debug.DrawRay(transform.position, newDirection, Color.red);

        gameObject.transform.rotation = Quaternion.LookRotation(newDirection);

        if (Input.GetMouseButtonDown(0))
        {
            Bullet clone = Instantiate(projectile, transform.position, transform.rotation);
            clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * Speed);
            clone.LifeSpan = BulletLifeSpan;
            clone.GameObject().SetActive(true);
        }

    }
}
