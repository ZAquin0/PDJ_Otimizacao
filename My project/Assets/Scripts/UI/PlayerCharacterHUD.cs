using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerCharacterHUD : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Slider jetpackFuelBar;
    [SerializeField] private TextMeshProUGUI jetpackFuelText;
    [SerializeField] private TextMeshProUGUI currencyText;
    [SerializeField] private Slider jetpackStaminaWheel;
    [SerializeField] private RectTransform jetpackStaminaWheelObject;
    private void Start()
    {
        jetpackFuelBar.maxValue = player.GetComponent<PlayerCharacterMovement>().maxFuel;
        jetpackFuelBar.value = player.GetComponent<PlayerCharacterMovement>().maxFuel;
        jetpackStaminaWheel.maxValue = player.GetComponent<PlayerCharacterMovement>().maxStamina;
        jetpackStaminaWheel.value = player.GetComponent<PlayerCharacterMovement>().maxStamina;
        jetpackStaminaWheelObject.gameObject.SetActive(false);
    }
    private void Update()
    {
        currencyText.text = $"Money: ${PlanetScene.currentMoney}";
        jetpackFuelBar.value = player.GetComponent<PlayerCharacterMovement>().currentFuel;
        jetpackFuelText.text = $"{(int) (jetpackFuelBar.value * 100 / jetpackFuelBar.maxValue)}%";
        jetpackStaminaWheel.value = player.GetComponent<PlayerCharacterMovement>().currentStamina;
        if(jetpackStaminaWheel.value >= jetpackStaminaWheel.maxValue) jetpackStaminaWheelObject.gameObject.SetActive(false);
        else jetpackStaminaWheelObject.gameObject.SetActive(true);
    }
}
