using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class resources : MonoBehaviour
{
    public int saplings = 20;
    public int money = 0;
    public Slider totalTrees;
    public TMP_Text SaplingCounter;
    public TMP_Text MoneyCounter;
    public TMP_Text saplingBuyDisplay;
    public TMP_Text saplingSellDisplay;
    public int saplingCost = 1;
    public int saplingValue = 2;

    public void addSaplings(int addAmount)
    {
        totalTrees.value += addAmount;
        //Debug.Log(addAmount + "added!");
        saplings += addAmount;
    }
    
    public void removeSaplings(int removeAmount)
    {
        //Debug.Log(removeAmount + "removed!");
        saplings -= removeAmount;
    }

    public void addMoney(int addAmount)
    {
        money += addAmount;
    }

    public void removeMoney(int removeAmount)
    {
        money -= removeAmount;
    }

    public void plantSapling()
    {
        if (money >= saplingCost)
        {
            money -= saplingCost;
            addSaplings(1);
        }
    }

    public void choptree()
    {
        if (saplings > 0)
        {
            removeSaplings(1);
            addMoney(saplingValue);
        }
    }

    private void Update()
    {
        SaplingCounter.text = Calculations.FormatNumber(saplings);
        MoneyCounter.text = Calculations.FormatNumber(money);
        saplingBuyDisplay.text = saplingCost.ToString();
        saplingSellDisplay.text = saplingValue.ToString();
    }
}
