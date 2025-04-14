using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmbarkShipNew : MonoBehaviour
{
    public bool aboard = false;
    [SerializeField] private string inputKey;
    [SerializeField] private Transform pilotCamera;
    [SerializeField] private Transform vehicleCamera;
    [SerializeField] private RectTransform playerCharacterHUD, playerShipHUD;
    [SerializeField] private LunarLanderMovement playerShipMovement;
    private PlayerCharacterMovement playerCharacterMovement;
    private void Start()
    {
        playerCharacterMovement = GetComponent<PlayerCharacterMovement>();
    }
    private void Update()
    {
        if(aboard)
        {
            pilotCamera.gameObject.SetActive(false);
            vehicleCamera.gameObject.SetActive(true);
            playerShipMovement.enabled = true;
            playerCharacterMovement.enabled = false;
            playerShipHUD.gameObject.SetActive(true);
            playerCharacterHUD.gameObject.SetActive(false);
        }
        else
        {
            pilotCamera.gameObject.SetActive(true);
            vehicleCamera.gameObject.SetActive(false);
            playerShipMovement.enabled = false;
            playerCharacterMovement.enabled = true;
            playerShipHUD.gameObject.SetActive(false);
            playerCharacterHUD.gameObject.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(!aboard && other.CompareTag("PlayerPlanetShip") && Input.GetKey(inputKey))
        {
            aboard = true;
        }
    }
}
