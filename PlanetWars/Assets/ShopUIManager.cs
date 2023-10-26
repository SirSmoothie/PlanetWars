using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShopUIManager : MonoBehaviour
{
    public TextMeshProUGUI currencyTextBlue;
    public TextMeshProUGUI currencyTextRed;

    public GameObject playerRed;
    public GameObject playerBlue;

    private void Update()
    {
        currencyTextBlue.text = playerBlue.GetComponent<PlayerInventory>().crystalCurrency.ToString();
        currencyTextRed.text = playerRed.GetComponent<PlayerInventory>().crystalCurrency.ToString();
    }
}
