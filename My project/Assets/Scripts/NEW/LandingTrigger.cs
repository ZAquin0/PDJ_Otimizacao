using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingTrigger : MonoBehaviour
{
    [SerializeField] private EmbarkShipNew embarkShip;
    [SerializeField] private GameObject landingShip;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PlayerPlanetShip"))
        {
            Vector3 vector3 = new Vector3(0, 2, 0);
            embarkShip.aboard = false;
            landingShip.transform.position = this.gameObject.transform.position + vector3;
            landingShip.transform.rotation = Quaternion.identity;
            landingShip.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        }
    }
}
