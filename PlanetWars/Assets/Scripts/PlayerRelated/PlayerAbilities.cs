
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public PlayerModel playerModel;
    public PlayerInventory inv;
    public ButtonEvent buyDash;
    public ButtonEvent buyDmg;
    public ButtonEvent buyRange;
    private int dmgLevel = 1;
    private int rangeLevel = 1;
    public int moreBulletDmg;
    public float moreBulletRange;

    private void OnEnable()
    {
        buyRange.ButtonPressedIntValueEvent += BuyRange;
        buyDash.ButtonPressedIntValueEvent += BuyDash;
        buyDmg.ButtonPressedIntValueEvent += BuyMoreDmg;
    }

    private void Start()
    {
        playerModel = gameObject.GetComponent<PlayerModel>();
    }

    void BuyMoreDmg(int dmgCost)
    {
        int dmgcost = dmgCost * dmgLevel;
        if (inv.crystalCurrency >= dmgcost)
        {
            dmgLevel++;
            inv.crystalCurrency -= dmgcost;
            playerModel.bulletDmg += moreBulletDmg;
        }
    }
    
    public delegate void DashBought();

    public event DashBought DashBoughtEvent;
    void BuyDash(int dashCost)
    {
        if (inv.crystalCurrency >= dashCost && !playerModel.dashAbility)
        {
            playerModel.dashAbility = true;
            inv.AddCrystals(-dashCost);
            DashBoughtEvent();
        }
    }

    void BuyRange(int rangeCost)
    {
        int rangecost = rangeCost * rangeLevel;
        if (inv.crystalCurrency >= rangecost)
        {
            rangeLevel++;
            inv.crystalCurrency -= rangeCost;
            playerModel.fireRange += moreBulletRange;
        }
    }
    private void OnDisable()
    {
        buyRange.ButtonPressedIntValueEvent -= BuyRange;
        buyDash.ButtonPressedIntValueEvent -= BuyDash;
        buyDmg.ButtonPressedIntValueEvent -= BuyMoreDmg;
    }
}
