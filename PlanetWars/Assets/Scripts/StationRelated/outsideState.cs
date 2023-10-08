using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outsideState : MonoBehaviour
{
    public ShopState shop;
    public GameObject stationCasing;
    private void OnEnable()
    {
        stationCasing.SetActive(true);
    }

    public void OnTriggerEnter(Collider other)
    {
        EnterShop();
    }

    void EnterShop()
    {
        gameObject.GetComponent<StateManager>().ChangeState(shop);
    }
    private void OnDisable()
    {
        stationCasing.SetActive(false);
    }
}
