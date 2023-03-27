using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class multiplier : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string itemName = "Unknown Upgrade";
    public bool Owned = false;
    public GameObject toolTip, icon;
    public int baseCost = 15;
    public int purchaseCost;
    public TMP_Text costText,sellHover,buyHover;
    public resources myResources;
    public int buyValue = 1;
    public int sellValue = 1;

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
            myResources.saplingCost = buyValue;
            myResources.saplingValue = sellValue;
            icon.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public void SetUi()
    {
        purchaseCost = baseCost;
        gameObject.name = itemName;
        costText.text = purchaseCost.ToString();
        sellHover.text = sellValue.ToString();
        buyHover.text = buyValue.ToString();
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
