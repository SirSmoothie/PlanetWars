using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public GameObject Player;
    public GameObject ColliderOfShip;

    public int SpaceshipIndex;

    private void OnEnable()
    {
        ColliderOfShip.GetComponent<Destroyable>().KillObjectEvent += Died;
    }

    public void Start()
    {
        SpaceshipIndex = Player.GetComponent<PlayerController>().PlayerIndex;
    }

    public void Died()
    {
        Player.GetComponent<PlayerController>().destroy();
    }
    private void OnDisable()
    {
        ColliderOfShip.GetComponent<Destroyable>().KillObjectEvent -= Died;
    }
}
