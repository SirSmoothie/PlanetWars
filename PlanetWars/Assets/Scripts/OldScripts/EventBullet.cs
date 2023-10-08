using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBullet : MonoBehaviour
{
    public int Value;
    public delegate void SimpleDelegate(int v);
	
// Define the actual event
    public event SimpleDelegate DeadEvent;
	
    public void Update()
    {
        // Fake death
        if (Input.GetKeyDown("g"))
        {
            Dead();
        }
    }
	
    public void Dead()
    {
        // Fire the event and check for null (the ?)
        DeadEvent?.Invoke(Value);
    }

}
