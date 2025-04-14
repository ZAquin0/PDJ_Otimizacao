using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private float orbitSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform parent;
    [SerializeField] private Vector3 RotationDirection;
    public void SetupAsteroid(float orbitSpeed, float rotationSpeed, Transform parent)
    {
        this.orbitSpeed = orbitSpeed;
        this.rotationSpeed = rotationSpeed;
        this.parent = parent;
        RotationDirection = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
    }
    private void FixedUpdate()
    {
        transform.RotateAround(parent.transform.position, parent.transform.up, -orbitSpeed * Time.deltaTime);
        transform.Rotate(RotationDirection, rotationSpeed * Time.deltaTime);
    }
}
