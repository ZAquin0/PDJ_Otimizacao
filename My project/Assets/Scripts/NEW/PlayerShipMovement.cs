using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerShipMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private ParticleSystem jetParticles;
    private ParticleSystem.EmissionModule jetEmisson;
    [SerializeField] private ParticleSystem smokeParticles;
    private ParticleSystem.EmissionModule smokeEmission;
    [Header("Fuel Atributes")]
    public float maxFuel;
    [SerializeField][Range(1, 5)] private float consumptionMultiplier;
    [SerializeField] private float maxConsumptionSpeed;
    [HideInInspector] public float currentFuel;
    [Header("Movement parameters")]
    [SerializeField] private bool moveUp = false;
    [SerializeField] private float maxVelocity;
    private float moveSpeed;
    [SerializeField] private float thrusterForce;
    [SerializeField] private float torqueForce;
    [SerializeField][Range(0.1f, 0.999f)] private float glideMultiplier;
    private Rigidbody playerShipRigidbody;
    private float row;
    private float pitch;
    private float yaw;
    private bool thruster;
    private float glide;
    private void Start()
    {
        playerShipRigidbody = GetComponent<Rigidbody>();
        moveSpeed = maxVelocity;

        jetEmisson = jetParticles.emission;
        smokeEmission = smokeParticles.emission;

        currentFuel = PlanetScene.currentFuel;
    }
    private void Update()
    {
        MoveInput();

        jetEmisson.enabled = thruster;
        smokeEmission.enabled = thruster;
        
        
    }
    private void FixedUpdate()
    {
        AdjustVelocity();
        MovePlayerShip();
    }
    private void MoveInput()
    {
        if(Input.GetKeyDown(KeyCode.Space)) thruster = !thruster;
        if (Input.GetKey(KeyCode.LeftShift)) thrusterForce = 2000f; else { thrusterForce = 500; }
        row = Input.GetAxisRaw("Horizontal");
        pitch = Input.GetAxis("Vertical");
        if(Input.GetKey(KeyCode.Q)) yaw = -1;
        else if(Input.GetKey(KeyCode.E)) yaw = 1;
        else yaw = 0;
    }
    private void MovePlayerShip()
    {
        playerShipRigidbody.AddRelativeTorque(Vector3.back * torqueForce * row * Time.fixedDeltaTime);
        playerShipRigidbody.AddRelativeTorque(Vector3.right * torqueForce * -pitch * Time.fixedDeltaTime);
        playerShipRigidbody.AddRelativeTorque(Vector3.down * torqueForce * -yaw * Time.fixedDeltaTime);

        if(!moveUp)
        {
            if(thruster)
            {
                playerShipRigidbody.AddRelativeForce(Vector3.forward * thrusterForce);
                glide = thrusterForce;
                ConsumeFuel(playerShipRigidbody.linearVelocity.magnitude + 1);
            }
            else
            {
                playerShipRigidbody.AddRelativeForce(Vector3.forward * glide);
                glide *= glideMultiplier;
            }
        }
        else
        {
            if(thruster)
            {
                playerShipRigidbody.AddRelativeForce(Vector3.up * thrusterForce);
                glide = thrusterForce;
                ConsumeFuel(playerShipRigidbody.linearVelocity.magnitude + 1);
            }
            else
            {
                playerShipRigidbody.AddRelativeForce(Vector3.up * glide);
                glide *= glideMultiplier;
            }
        }
    }
    private void AdjustVelocity()
    {
        if(playerShipRigidbody.linearVelocity.magnitude > moveSpeed)
        {
            Vector3 flatVelocity = playerShipRigidbody.linearVelocity.normalized * moveSpeed;
            playerShipRigidbody.linearVelocity = flatVelocity;
        }
    }
    public void ConsumeFuel(float consumptionRate) 
    {
        if(consumptionRate > maxConsumptionSpeed) consumptionRate = maxConsumptionSpeed;
        currentFuel -= consumptionRate * consumptionMultiplier * Time.deltaTime;
    }
    public void Refuel(float amount) => currentFuel += amount * Time.deltaTime;
    public void SetFuel(float amount) => currentFuel += amount;
}
