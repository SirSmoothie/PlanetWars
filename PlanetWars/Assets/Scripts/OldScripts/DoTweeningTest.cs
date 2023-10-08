using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DoTweeningTest : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.DOMoveY(transform.position.y + 5, 5);
    }
}
