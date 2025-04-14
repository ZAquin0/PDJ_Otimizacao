using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GasStation : MonoBehaviour
{
    [SerializeField] private PlayerShipThruster playerShip;
    [SerializeField] private RectTransform refillButton, sellButton;
    [SerializeField] private TextMeshProUGUI refillCostText;
    [SerializeField] private TextMeshProUGUI currencyText;
    [SerializeField] private Slider fuelBar;
    [SerializeField] private int buyPrice;
    [SerializeField] private int sellPrice;
    [SerializeField] private float fuelToAdd;
    [SerializeField] private int priceToPay;
    private void OnEnable()
    {
        fuelBar.maxValue = playerShip.maxFuel;
        fuelBar.value = playerShip.currentFuel;
        fuelToAdd = 0;
        currencyText.text = $"${PlanetScene.currentMoney}";
    }
    public void ValueChangeCheck()
    {
        fuelToAdd = fuelBar.value - playerShip.currentFuel;
        currencyText.text = $"${PlanetScene.currentMoney}";
        sellButton.gameObject.SetActive(false);
        refillButton.gameObject.SetActive(false);
        if(fuelToAdd > 0) 
        {
            priceToPay = (int)(fuelToAdd / buyPrice);
            if(priceToPay < 1) priceToPay = 1;
            refillButton.gameObject.SetActive(true);
        }
        else if(fuelToAdd < 0)
        {
            priceToPay = (int)(fuelToAdd / sellPrice);
            sellButton.gameObject.SetActive(true);
        }
        else priceToPay = 0;
        refillCostText.text = $"Cost = ${priceToPay}";
    }
    public void Refill()
    {
        if(PlanetScene.currentMoney > priceToPay)
        {
            playerShip.SetFuel(fuelToAdd);
            PlanetScene.currentMoney -= priceToPay;
            ValueChangeCheck();
        }
    }
}
