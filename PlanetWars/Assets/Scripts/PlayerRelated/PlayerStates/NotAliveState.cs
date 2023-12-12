using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotAliveState : MonoBehaviour
{
    public GameObject View;
    private void OnEnable()
    {
        GameManager.Instance.Players.Remove(gameObject);
        View.gameObject.SetActive(false);
    }
}
