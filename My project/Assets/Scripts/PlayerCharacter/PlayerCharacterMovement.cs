using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerCharacterMovement : MonoBehaviour
{
    [Header("Horizontal")]
    [SerializeField] private float speed;
    private CharacterController controller;
    private Vector3 movement;
    [Header("Vertical")]
    [SerializeField] private float gravity;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jetpackInitialForce;
    [SerializeField] private float jetpackForce;
    [SerializeField] private float jetpackInitialDelay;
    [SerializeField] private float jetpackDelay;
    private bool canJump = true;
    private Vector3 gravitySpeed;
    private float initialTimer, timer;
    [Header("Fuel Values")]
    public float maxFuel;
    [SerializeField] private float comsumptionRate;
    [HideInInspector] public float currentFuel;
    [HideInInspector] public float maxStamina;
    [HideInInspector] public float currentStamina;
    [Header("Visuals")]
    [SerializeField] private ParticleSystem jetpackJetParticles;
    [SerializeField] private ParticleSystem jetpackSmokeParticles;
    [SerializeField] private Animator animator;
    private ParticleSystem.EmissionModule jetEmission, smokeEmission;
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        initialTimer = timer = 0;
        jetEmission = jetpackJetParticles.emission;
        smokeEmission = jetpackSmokeParticles.emission;
        currentFuel = PlanetScene.currentJetpackFuel;
        currentStamina = maxStamina = jetpackInitialDelay;
    }
    private void Update()
    {
        canJump = controller.isGrounded;
        movement = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
        if(canJump)
        {
            currentStamina = jetpackInitialDelay;
            jetEmission.enabled = false;
            smokeEmission.enabled = false;
        }
        if(canJump && gravitySpeed.y < 0) gravitySpeed.y = 0f;
        if(canJump && Input.GetButtonDown("Jump"))
        {
            Jump(jumpForce);
            animator.Play("JUMP");
        } 
        if(jetpackInitialDelay > jetpackDelay) jetpackDelay = jetpackInitialDelay;
        else if(!canJump && Input.GetButton("Jump"))
        {
            if(initialTimer < jetpackInitialDelay) initialTimer += Time.deltaTime;
            else if(timer < jetpackDelay)
            {
                timer += Time.deltaTime;
                currentStamina -= timer * Time.deltaTime;
                currentFuel -= comsumptionRate * Time.deltaTime;
                jetEmission.enabled = true;
                smokeEmission.enabled = true;
                Jump(jetpackInitialForce * Time.deltaTime);
            }
            else 
            {
                jetEmission.enabled = true;
                smokeEmission.enabled = true;
                currentStamina -= timer * Time.deltaTime;
                currentFuel -= comsumptionRate * Time.deltaTime;
                Jump(jetpackForce * Time.deltaTime);
            }
        }
        if(Input.GetButtonUp("Jump"))
        {
            jetEmission.enabled = false;
            smokeEmission.enabled = false;
            initialTimer = 0;
            timer = 0;
        }
    }
    private void FixedUpdate()
    {
        controller.Move(movement * speed * Time.fixedDeltaTime);
        animator.SetFloat("Speed", movement.magnitude);
        gravitySpeed.y += gravity * Time.fixedDeltaTime;
        controller.Move(gravitySpeed * Time.fixedDeltaTime);
    }
    public void Jump(float jumpForce) => gravitySpeed.y += jumpForce;
}
