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
     public Vector3 DirectionToObject;
     public float multipler;
     public float MaxDis;
     private void Start()
     {
          _objectsInField = new List<GameObject>();
     }

     private void FixedUpdate()
     {
          
          //Finds all instances of an object with the component Rigidbody
          foreach (var rigidbody1 in FindObjectsByType<Rigidbody>(FindObjectsInactive.Exclude, FindObjectsSortMode.None))
          {
          }
          
          
          foreach (var RigidBody1 in _objectsInField)
          {
               DistanceX = transform.position.x - RigidBody1.transform.position.x;
               DistanceY = transform.position.y - RigidBody1.transform.position.y;
               Distance = Mathf.Sqrt((DistanceX * DistanceX) + (DistanceY * DistanceY));
               
               GravityForce = Mathf.Pow(Mathf.Log(2f, Distance)+ 1, multipler);
               RigidBody1.GetComponent<Rigidbody>().AddForce((transform.position - RigidBody1.transform.position) * GravityForce);
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
