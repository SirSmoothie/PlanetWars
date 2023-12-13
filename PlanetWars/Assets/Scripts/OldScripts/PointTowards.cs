using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTowards : MonoBehaviour
{
    public GameObject pointTo;
    public float maxRadians;
    public GameObject Player;
    private int ourIndex;

    private void Start()
    {
        ourIndex = Player.GetComponent<PlayerController>().PlayerIndex;
    }

    public void Update()
    {
        if (pointTo == null)
        {
            FindStation();
        }
            //sets the objects location to the gameobjects position PointToLast if the playerActivator is not active.
            Vector3 targetDirection = pointTo.transform.position - gameObject.transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, maxRadians, 0f);
            gameObject.transform.rotation = Quaternion.LookRotation(newDirection);
    }

    public void FindStation()
    {
        var pointTolist = FindObjectsOfType<SpaceShip>();

        foreach (var VARIABLE in pointTolist)
        {
            if (VARIABLE.SpaceshipIndex == ourIndex)
            {
                return;
            }
            pointTo = VARIABLE.transform.gameObject;
        }
    }
}
