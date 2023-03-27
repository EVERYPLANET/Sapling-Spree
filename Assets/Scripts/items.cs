using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class items : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public string itemName = "Unknown Upgrade";
    public int numberOwned = 0;
    public int baseCost = 15;
    public int purchaseCost;
    public GameObject toolTip;
    public TMP_Text numberText, costText, buttonText, saplingsHover, choppedHover;
    public resources myResources;
    public float clicksPerSecond = 0.1f;
    public int convertPerSecond = 1;

    //private float timer = 0f;
    
    // Start is called before the first frame update
    void Start()
    {       
        SetUi();
    }
    
    public void PurchaseItem()
    {
        if(myResources.money >= purchaseCost)
        {
            myResources.removeMoney(purchaseCost);
            numberOwned++;
            if (clicksPerSecond > 0)
            {
                InvokeRepeating("AutoClick", 1 / clicksPerSecond, 1 / clicksPerSecond);
            }
            
            if (convertPerSecond > 0)
            {
                InvokeRepeating("AutoConvert", 1 / (float)convertPerSecond, 1 / (float)convertPerSecond);
            }

            SetUi();
            //timer -= clickTime;
        }
    }

    public void SetUi()
    {
        purchaseCost = Calculations.ExponentialCost(baseCost, numberOwned);
        gameObject.name = itemName;
        buttonText.text = itemName;
        numberText.text = numberOwned.ToString();
        costText.text = Calculations.FormatNumber(purchaseCost);
        saplingsHover.text = (clicksPerSecond*(numberOwned+1)).ToString();
        choppedHover.text = (convertPerSecond*(numberOwned+1)).ToString();
    }
    
    private void AutoClick()
    {
        myResources.addSaplings(numberOwned);
        
    }

    private void AutoConvert()
    {
        if (myResources.saplings > 0)
        {
            myResources.removeSaplings(convertPerSecond);
            myResources.addMoney(myResources.saplingValue); 
        }
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        toolTip.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        toolTip.SetActive(false);
    }
}