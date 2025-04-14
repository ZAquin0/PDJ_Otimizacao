using System;
using UnityEngine;

[Serializable]
public struct SpaceObject
{
    [Header("Identification Values")]
    public String name;
    public int id;
    [Header("Construction Values")]
    public Transform outiline;
    public Transform spaceObject;
    public int[] sunIndexes;
    public int refIndex;
    public float exitRadius;
    public float exitVelocity;
    public float rotationSpeed;
    [Header("Gravity Value")]
    public bool isPlayer;
}
public class SolarSystem : MonoBehaviour
{
    [SerializeField] private float g = 3f;
    public SpaceObject[] spaceObjects;
    private int playerIndex = 11;
    private void Start()
    {
        SetInitialPosition();
        if(PlanetScene.planetIndex != -1) PlanetLeft();
        SetInitialVelocity();
    }
    private void FixedUpdate() => Gravity();
    private void Gravity()
    {
        foreach(SpaceObject objectA in spaceObjects)
        {
            if(objectA.isPlayer)
            {
                foreach(SpaceObject objectB in spaceObjects)
                {
                    if(!objectA.Equals(objectB))
                    {
                        float massA = objectA.spaceObject.GetComponent<Rigidbody>().mass;
                        float massB = objectB.spaceObject.GetComponent<Rigidbody>().mass;
                        float r = Vector3.Distance(objectA.spaceObject.position, objectB.spaceObject.position);
                        if(r != 0) objectA.spaceObject.GetComponent<Rigidbody>().AddForce((objectB.spaceObject.position - objectA.spaceObject.position).normalized * (g * (massA * massB) / (r * r)));
                    }
                }
            }
            else
            {
                foreach(int sunIndex in objectA.sunIndexes)
                {
                    SpaceObject objectB = spaceObjects[sunIndex];
                    float massA = objectA.spaceObject.GetComponent<Rigidbody>().mass;
                    float massB = objectB.spaceObject.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(objectA.spaceObject.position, objectB.spaceObject.position);
                    if(r != 0) objectA.spaceObject.GetComponent<Rigidbody>().AddForce((objectB.spaceObject.position - objectA.spaceObject.position).normalized * (g * (massA * massB) / (r * r)));
                }
            }
        }
    }
    private void SetInitialPosition()
    {
        Vector3[] newPositions = new Vector3[spaceObjects.Length];
        for(int index = 0; index < spaceObjects.Length; index++)
        {
            SpaceObject celestial = spaceObjects[index];
            Vector3 vectorRadius = celestial.spaceObject.position - spaceObjects[celestial.refIndex].spaceObject.position;
            Vector2 circumference = UnityEngine.Random.insideUnitCircle.normalized * vectorRadius.magnitude;
            newPositions[index] = new Vector3(circumference.x, vectorRadius.y, circumference.y) + newPositions[celestial.refIndex];
        }
        for(int index = 0; index < spaceObjects.Length; index++)
        {
            SpaceObject celestial = spaceObjects[index];
            celestial.spaceObject.position = newPositions[index];
            TrailRenderer trailRenderer = celestial.spaceObject.GetComponent<TrailRenderer>();
            if(trailRenderer != null) trailRenderer.Clear();
        }
    }
    private void SetInitialVelocity()
    {
        foreach(SpaceObject celestial in spaceObjects)
        {
            celestial.spaceObject.GetComponent<Rigidbody>().angularVelocity = celestial.spaceObject.up * celestial.rotationSpeed;
            foreach(int sunIndex in celestial.sunIndexes)
            {
                Transform sun = spaceObjects[sunIndex].spaceObject;
                float sunMass = sun.GetComponent<Rigidbody>().mass;
                float radius = Vector3.Distance(celestial.spaceObject.position, sun.position);
                celestial.spaceObject.LookAt(sun);
                if(radius != 0) celestial.spaceObject.GetComponent<Rigidbody>().linearVelocity += celestial.spaceObject.right * Mathf.Sqrt((g * sunMass) / radius);
            }
            //Debug.Log($"Speed of planet {celestial.name}({celestial.id}) is: {celestial.spaceObject.GetComponent<Rigidbody>().velocity.magnitude}");  
        }
    }
    public void PlanetLeft()
    {
        SpaceObject exitPlanet = spaceObjects[PlanetScene.planetIndex];
        Vector3 planetPosition = new Vector3(exitPlanet.spaceObject.position.x, exitPlanet.spaceObject.position.y + exitPlanet.exitRadius, exitPlanet.spaceObject.position.z);
        spaceObjects[playerIndex].spaceObject.position = planetPosition;
        spaceObjects[playerIndex].spaceObject.GetComponent<Rigidbody>().linearVelocity = Vector3.up * spaceObjects[playerIndex].exitVelocity;
    }
}
