using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PlanetShipHUD : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private TextMeshProUGUI currencyText, velocityText, heightText, fuelBarText;
    [SerializeField] private Slider fuelBar;
    private void Start()
    {
        fuelBar.maxValue = player.GetComponent<LunarLanderMovement>().maxFuel;
        fuelBar.value = player.GetComponent<LunarLanderMovement>().maxFuel;
    }
    private void Update()
    {
        currencyText.text = $"Money: ${PlanetScene.currentMoney}";
        //if(player.GetComponent<Rigidbody>().velocity.magnitude > player.GetComponent<PlayerShipHealth>().speedThreshold && player.position.y < 300) velocityText.color = Color.red;
        //else velocityText.color = Color.white;
        velocityText.text = $"Velocity: {(int) player.GetComponent<Rigidbody>().linearVelocity.magnitude}";
        heightText.text = $"Height: {(int) player.position.y}";
        fuelBar.value = player.GetComponent<LunarLanderMovement>().currentFuel;
        fuelBarText.text = $"{(int) (fuelBar.value * 100 / fuelBar.maxValue)}%";
    }
}
