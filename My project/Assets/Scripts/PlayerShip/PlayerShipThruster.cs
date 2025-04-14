using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShipThruster : MonoBehaviour
{
    [Header("Thruster Atributes")]
    [SerializeField] private ParticleSystem smokeParticles,jetParticles;
    [SerializeField] private float maximumVelocity;
    [SerializeField] private float thrustersForce;
    [SerializeField] private float startDelay;
    public float maxFuel;
    [SerializeField][Range(1, 5)] private float consumptionMultiplier;
    [SerializeField] private float maxConsumptionSpeed;
    private float timer;
    [HideInInspector] public float currentFuel;
    private Rigidbody rigidbody;
    private ParticleSystem.EmissionModule smokeEmission, jetEmission;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        timer = startDelay; 
        smokeEmission = smokeParticles.emission;
        jetEmission = jetParticles.emission;
        currentFuel = PlanetScene.currentFuel;
    }
    private void Update()
    {
        if(rigidbody.linearVelocity.magnitude > maximumVelocity) rigidbody.linearVelocity = rigidbody.linearVelocity.normalized * maximumVelocity;
        if(currentFuel > maxFuel) currentFuel = maxFuel;
        else if(currentFuel < 0) currentFuel = 0;
        if(Input.GetMouseButton(0) && currentFuel != 0)
        {
            if(timer <= 0)
            {
                rigidbody.AddForce(this.transform.up * thrustersForce * Time.deltaTime);
                ConsumeFuel(rigidbody.linearVelocity.magnitude + 1);
                smokeEmission.enabled = true;  
                jetEmission.enabled = true;
            }
            timer -= Time.deltaTime;
        }
        else 
        {
            timer = startDelay;
            smokeEmission.enabled = false;
            jetEmission.enabled = false;
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
