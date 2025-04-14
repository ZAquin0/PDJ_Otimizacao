using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class SpaceShipHUD : MonoBehaviour
{
    [SerializeField] private Transform player, sun;
    [SerializeField] private float sunRadius;
    [SerializeField] private TextMeshProUGUI velocityText, sunDistanceText, fuelBarText, currencyText;
    [SerializeField] private Slider fuelBar;
    private void Start()
    {
        fuelBar.maxValue = player.GetComponent<PlayerShipMovement>().maxFuel;
        fuelBar.value = player.GetComponent<PlayerShipMovement>().maxFuel;
    }
    private void Update()
    {
        currencyText.text = $"Money: ${PlanetScene.currentMoney}";
        velocityText.text = $"Velocity: {(int) player.GetComponent<Rigidbody>().linearVelocity.magnitude}";
        Vector3 direction = player.position - sun.position;
        if(direction.magnitude - sunRadius < 1500) sunDistanceText.color = Color.red;
        else sunDistanceText.color = Color.white;
        sunDistanceText.text = $"Sun Distance: {(int) direction.magnitude - sunRadius}";
        fuelBar.value = player.GetComponent<PlayerShipMovement>().currentFuel;
        fuelBarText.text = $"{(int) (fuelBar.value * 100 / fuelBar.maxValue)}%";
    }
}
