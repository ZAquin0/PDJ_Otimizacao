using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandingShipMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private ParticleSystem flameParticles;
    private ParticleSystem.EmissionModule flameEmission;
    [SerializeField] private ParticleSystem smokeParticles;
    private ParticleSystem.EmissionModule smokeEmission;
}
