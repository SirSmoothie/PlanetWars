
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public PlayerController playerController;
    public PlayerInventory inv;
    public ButtonEvent buyDash;
    public ButtonEvent buyDmg;
    private int dmgLevel;
    public int moreBulletDmg;

    private void OnEnable()
    {
        buyDash.ButtonPressedIntValueEvent += BuyDash;
        buyDmg.ButtonPressedIntValueEvent += BuyMoreDmg;
    }

    private void Start()
    {
        playerController = gameObject.GetComponent<PlayerController>();
    }

    void BuyMoreDmg(int dmgCost)
    {
        int dmgcost = dmgCost * dmgLevel;
        if (inv.crystalCurrency >= dmgcost)
        {
            dmgLevel++;
            inv.crystalCurrency -= dmgcost;
            playerController.bulletDmg += moreBulletDmg;
        }
    }

    void BuyDash(int dashCost)
    {
        if (inv.crystalCurrency >= dashCost && !playerController.dashAbility)
        {
            playerController.dashAbility = true;
            inv.AddCrystals(-dashCost);
        }
    }

    private void OnDisable()
    {
        buyDash.ButtonPressedIntValueEvent -= BuyDash;
        buyDmg.ButtonPressedIntValueEvent -= BuyMoreDmg;
    }
}
