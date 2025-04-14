using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBelt : MonoBehaviour
{
    [Header("Spawner Settings")]
    [SerializeField] private Transform asteroid;
    [SerializeField] private int quantity;
    //[SerializeField] private int seed;
    [SerializeField] private float innerRadius;
    [SerializeField] private float outerRadius;
    [SerializeField] private float height;
    [Header("Asteroid Values")]
    [SerializeField] private float maxSize;
    [SerializeField] private float minSize;
    [SerializeField] private float maxOrbitSpeed;
    [SerializeField] private float minOrbitSpeed;
    [SerializeField] private float maxRotationSpeed;
    [SerializeField] private float minRotationSpeed;
    private Vector3 localPosition;
    private Vector3 worldOffset;
    private Vector3 worldPosition;
    private float randomRadius;
    private float randomRadian;
    private float x, y, z;
    private void Start()
    {
        for(int index = 0; index < quantity; index++)
        {
            do
            {
                randomRadius = Random.Range(innerRadius, outerRadius);
                randomRadian = Random.Range(0, 2 * Mathf.PI);
                y = Random.Range(-height / 2, height / 2);
                x = randomRadius * Mathf.Cos(randomRadian);
                z = randomRadius * Mathf.Sin(randomRadian);
            }
            while(float.IsNaN(z) && float.IsNaN(x));
            localPosition = new Vector3(x, y ,z);
            worldOffset = transform.rotation * localPosition;
            worldPosition = transform.position + worldOffset;
            Transform asteroidInstance = Instantiate(asteroid, worldPosition, Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
            float randomScale = Random.Range(minSize, maxSize);
            asteroidInstance.localScale = new Vector3(randomScale, randomScale, randomScale);
            asteroidInstance.GetComponent<Asteroid>().SetupAsteroid(Random.Range(minOrbitSpeed, maxOrbitSpeed), Random.Range(minRotationSpeed, maxRotationSpeed), this.transform);
            asteroidInstance.SetParent(this.transform);
        }
    }
}
