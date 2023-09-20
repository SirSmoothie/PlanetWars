using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Gravity : MonoBehaviour
{
     public List<GameObject> _objectsInField;
     public float Distance;
     public float DistanceX;
     public float DistanceY;
     public float GravityForce;
     private void Start()
     {
          _objectsInField = new List<GameObject>();
     }

     private void Update()
     {
          /*
          //Finds all instances of an object with the component Rigidbody
          foreach (var rigidbody1 in FindObjectsByType<Rigidbody>(FindObjectsInactive.Exclude, FindObjectsSortMode.None))
          {
               DistanceX = transform.position.x - rigidbody1.transform.position.x;
               DistanceY = transform.position.y - rigidbody1.transform.position.y;
               Distance = Mathf.Sqrt((DistanceX * DistanceX) + (DistanceY * DistanceY));
               //The Amount of force being applied to other rigidbodys...
               GravityMultiplier = Mathf.Pow( GravityForce,  Distance);
               rigidbody1.AddForce(transform.position - rigidbody1.transform.position * GravityMultiplier);
               
          }
          */
          foreach (var RigidBody1 in _objectsInField)
          {
               //RigidBody1.GetComponent<Rigidbody>().AddForce(transform.position - RigidBody1.transform.position);
               
               
               //Making Gravity effect less the futher away and more when the object is closer.
               DistanceX = transform.position.x - RigidBody1.transform.position.x;
               DistanceY = transform.position.y - RigidBody1.transform.position.y;
               Distance = Mathf.Sqrt((DistanceX * DistanceX) + (DistanceY * DistanceY));
               //GravityForce = Mathf.Pow(-2, Distance);
               RigidBody1.GetComponent<Rigidbody>().AddForce(transform.position - RigidBody1.transform.position * GravityForce);
               Debug.Log(transform.position - RigidBody1.transform.position * -GravityForce);
          }
     }

     private void OnTriggerEnter(Collider other)
     {
          if (!_objectsInField.Contains(other.gameObject))
          {
               _objectsInField.Add(other.gameObject);
          }
     }

     private void OnTriggerExit(Collider other)
     {
          _objectsInField.Remove(other.gameObject);
     }
}
