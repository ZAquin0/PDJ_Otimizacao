using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class LunarLanderMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private ParticleSystem jetParticles;
    private ParticleSystem.EmissionModule jetEmisson;
    [SerializeField] private ParticleSystem smokeParticles;
    private ParticleSystem.EmissionModule smokeEmission;
    [Header("Start Atributes")]
    [SerializeField] private float positionLimit;
    private Vector2 randomPosition;
    [SerializeField] private float startinHeight;
    [SerializeField][Range(0, 360)] private float maxAngle;
    [Header("Fuel Atributes")]
    public float maxFuel;
    [SerializeField][Range(1, 5)] private float consumptionMultiplier;
    [SerializeField] private float maxConsumptionSpeed;
    [HideInInspector] public float currentFuel;
    [Header("Movement Atributes")]
    [SerializeField] private float thrusterForce;
    [SerializeField] private float torqueForce;
    [SerializeField] private float glideMultiplier;
    [Header("Gravity Atributes")]
    [SerializeField] private float maxVelocity;
    private float moveSpeed;
    [SerializeField][Range(-1, 1)] private float gForceX = 0f;
    [SerializeField][Range(-1, 1)] private float gForceY = 0f;
    Vector2 gravityRange;
    [SerializeField][Min(0)] private float gravity;
    private Rigidbody playerShipRigidbody;
    private float row;
    private bool thruster;
    private void Start()
    {
        randomPosition.x = Random.Range(-positionLimit, positionLimit);
        randomPosition.y = startinHeight;
        this.transform.position = randomPosition;

        float randomAngleZ = Random.Range(-maxAngle, maxAngle);
        this.transform.rotation = Quaternion.AngleAxis(randomAngleZ, Vector3.forward) * this.transform.rotation;

        gravityRange = new Vector2(gForceX, gForceY);

        playerShipRigidbody = GetComponent<Rigidbody>();
        moveSpeed = maxVelocity;

        jetEmisson = jetParticles.emission;
        smokeEmission = smokeParticles.emission;

        currentFuel = maxFuel;
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
        Gravity();
        MovePlayerShip();
    }
    private void MoveInput()
    {
        row = Input.GetAxisRaw("Horizontal");
        thruster = Input.GetKey(KeyCode.Space);
    }
    private void MovePlayerShip()
    {
        playerShipRigidbody.AddRelativeTorque(Vector3.back * torqueForce * row * Time.fixedDeltaTime);

        if(thruster)
        {
            playerShipRigidbody.AddRelativeForce(Vector3.up * thrusterForce, ForceMode.Acceleration);
            ConsumeFuel(playerShipRigidbody.linearVelocity.magnitude + 1);
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
    private void Gravity()
    {
        playerShipRigidbody.AddForce(gravityRange * gravity, ForceMode.Force);
    }
    public void ConsumeFuel(float consumptionRate) 
    {
        if(consumptionRate > maxConsumptionSpeed) consumptionRate = maxConsumptionSpeed;
        currentFuel -= consumptionRate * consumptionMultiplier * Time.deltaTime;
    }
    public void Refuel(float amount) => currentFuel += amount * Time.deltaTime;
    public void SetFuel(float amount) => currentFuel += amount;
}
