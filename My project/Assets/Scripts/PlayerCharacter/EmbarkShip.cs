using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EmbarkShip : MonoBehaviour
{
    public bool aboard = false;
    [SerializeField] private string inputKey;
    [SerializeField] private float inputDelay;
    [SerializeField] private Collider pilot;
    [SerializeField] private Transform pilotCamera;
    [SerializeField] private Transform vehicle, vehicleCamera;
    [SerializeField] private PlayerShipThruster playerShipThruster;
    [SerializeField] private PlayerShipRotation playerShipRotation;
    [SerializeField] private PlayerShipMovement playerShipMovement;
    [SerializeField] private Vector3 offset;
    [SerializeField] private RectTransform playerCharacterHUD, playerShipHUD;
    private PlayerCharacterMovement playerCharacterMovement;
    private float timer;
    private void Start()
    {
        playerCharacterMovement = GetComponent<PlayerCharacterMovement>();
        timer = 0;
    }
    private void Update()
    {
        if(aboard && timer < inputDelay)
        {
            timer += Time.deltaTime;
            transform.position = vehicle.position;
            pilotCamera.gameObject.SetActive(false);
            vehicleCamera.gameObject.SetActive(true);
            pilot.enabled = false;
            //playerShipThruster.enabled = true;
            //playerShipRotation.enabled = true;
            playerShipMovement.enabled = true;
            playerCharacterMovement.enabled = false;
            playerShipHUD.gameObject.SetActive(true);
            playerCharacterHUD.gameObject.SetActive(false);
        }
        else if(aboard && Input.GetKey(inputKey))
        {
            transform.position = vehicle.position + offset;
            pilotCamera.gameObject.SetActive(true);
            vehicleCamera.gameObject.SetActive(false);
            pilot.enabled = true;
            //playerShipThruster.enabled = false;
            //playerShipRotation.enabled = false;
            playerShipMovement.enabled = false;
            playerCharacterMovement.enabled = true;
            playerShipHUD.gameObject.SetActive(false);
            playerCharacterHUD.gameObject.SetActive(true);
            aboard = false;
            timer = 0;
        }
        if(aboard) transform.position = vehicle.position;
    }
    private void OnTriggerStay(Collider other)
    {
        if(!aboard && timer < inputDelay) timer += Time.deltaTime;
        else if(!aboard && other.CompareTag("PlayerPlanetShip") && Input.GetKey(inputKey))
        {
            aboard = true;
            timer = 0;
        }
    }
}
