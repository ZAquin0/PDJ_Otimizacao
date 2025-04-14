using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SearchService;
using UnityEngine.UI;

public class PlayerCharacterHealth : MonoBehaviour
{
    [Header("Values")]
    public float health;
    [SerializeField] private float velocityThreshould, maxHurtVelocity, healthRegenDelay;
    [SerializeField] private int regenAmount;
    [SerializeField][Range(1,100)] private float falldamageResistance = 1;
    [Header("Cosmetic")]
    [SerializeField] private int bloodThreshold;
    [SerializeField] private Transform bloodParticles;
    [HideInInspector] public float maxHealth;
    [SerializeField] private GameOver gameOverComponent;
    private float timer = 0;
    private float currentVelocity;
    private CharacterController controller;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        maxHealth = health;
    }
    private void Update()
    {
        currentVelocity = controller.velocity.magnitude;
        if(currentVelocity > maxHurtVelocity) currentVelocity = maxHurtVelocity;

        if(health < maxHealth) 
        {
            if(timer < healthRegenDelay) timer += Time.deltaTime;
            else health += regenAmount * Time.deltaTime;
        }

        if(health >= maxHealth)
        {
            health = maxHealth;
            timer = 0;
        }
    }
    private void FallDamage(float velocity)
    {
        timer = 0;
        int damage = (int) (velocity / falldamageResistance);
        health -= damage;
        if(damage > bloodThreshold) Instantiate(bloodParticles, transform.position, Quaternion.identity);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(currentVelocity >= velocityThreshould) FallDamage(currentVelocity);
        if(health <= 0) StartCoroutine(gameOverComponent.ActivateGameOver(this.gameObject));
    }
}
