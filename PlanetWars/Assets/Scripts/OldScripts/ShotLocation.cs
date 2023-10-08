using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotLocation : MonoBehaviour
{
    public float offset = 3f;
    public Vector3 Mousepos;
    public bool wasShot;
    public bool waitingToShoot;
    void Update()
    {
        //waits for the bool was shot to be recived (Aiming script sends it)
        //Then shoots a one time loop where it finds the position of the mouse and sets the game object to that location as a visual reminder for players for their next turn.
        if (wasShot)
        {
            
            Mousepos = Input.mousePosition;
            Mousepos.z = offset;
            transform.position = Camera.main.ScreenToWorldPoint(Mousepos);
            wasShot = false;
        }
        //I lost where this value gets changed from...........
        if (waitingToShoot)
        {
            //this is activated as long as waitingToShoot is true and then when the cannon is shot it gets set to false? (still dont know where tho).
            Mousepos = Input.mousePosition;
            Mousepos.z = offset;
            transform.position = Camera.main.ScreenToWorldPoint(Mousepos);
        }
    }
}
