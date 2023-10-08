using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Gravity : MonoBehaviour
{
     private List<GameObject> _objectsInField;
     private float Distance;
     private float DistanceX;
     private float DistanceY;
     private float GravityForce;
     
     //this value changes with the size of the Collider on the object
     public float MaxDis;
     
     public AnimationCurve gravityCurve;
     private float gravityCurveTimer;
     public float gravityMultiplier;
     private void Start()
     {
          //This deletes all previous gameobjects in the list
          _objectsInField = new List<GameObject>();
     }

     private void Update()
     {
          //removes every inactive copy of a bullet in the lists.
          for (int i = 0; i < _objectsInField.Count; i++)
          {
               if (!_objectsInField[i].activeSelf)
               {
                    _objectsInField.RemoveAt(i);
               }
          }
     }

     private void FixedUpdate()
     {
          
          //cycles through each Game Object in the list
          foreach (var RigidBody1 in _objectsInField)
          {
               //this just finds the distance between the two objects first object being what ever this script is attached to and then another Game Object in the list.
               DistanceX = transform.position.x - RigidBody1.transform.position.x;
               DistanceY = transform.position.y - RigidBody1.transform.position.y;
               Distance = Mathf.Sqrt((DistanceX * DistanceX) + (DistanceY * DistanceY));
               
               //Uses the Evaluate function to find the value to assign to GravityForce, Distance is / by Max distance to return a value between 1 and 0.
               gravityCurveTimer = Distance / MaxDis;
               GravityForce = gravityCurve.Evaluate(gravityCurveTimer);
               
               //old code that tried doing the curve of force via a exponential equation (unity doesnt like negative logs).
               /*
               DistanceX = transform.position.x - RigidBody1.transform.position.x;
               DistanceY = transform.position.y - RigidBody1.transform.position.y;
               Distance = Mathf.Sqrt((DistanceX * DistanceX) + (DistanceY * DistanceY));
               
               GravityForce = Mathf.Pow(Mathf.Log(2f, Distance)+ 1, multipler);
               */
               
               //Applies the final gravity force value to a constant changable value, gravityMultiplier that can change to manipulate the strength of gravity for things like suns.
               RigidBody1.GetComponent<Rigidbody>().AddForce((transform.position - RigidBody1.transform.position) * (GravityForce * gravityMultiplier));
          }
     }

     private void OnTriggerEnter(Collider other)
     {
          //When something enters the trigger of the gameObject it gets added to the list.
          if (!_objectsInField.Contains(other.gameObject))
          {
               _objectsInField.Add(other.gameObject);
          }
     }

     private void OnTriggerExit(Collider other)
     {
          //When something exits the trigger of the gameObject it gets removed from the list.
          _objectsInField.Remove(other.gameObject);
     }
     
}
