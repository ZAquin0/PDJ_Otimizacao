using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipHealth : MonoBehaviour
{
    public float speedThreshold;
    [SerializeField] private Transform explosion;
    [SerializeField] private GameOver gameOverComponent;
    private float currentVelocity;
    private Rigidbody rigidbody;
    private void Start() => rigidbody = GetComponent<Rigidbody>();
    private void Update() 
    {
        speedThreshold = PlanetScene.currentSpeedThreshold;
        currentVelocity = rigidbody.linearVelocity.magnitude;
    }
    private void OnCollisionEnter(Collision other)
    {
        if(currentVelocity >= speedThreshold) 
        {
            explosion.gameObject.GetComponent<ParticleSystem>().Play();
            StartCoroutine(gameOverComponent.ActivateGameOver(this.gameObject));
        }
    }
}
