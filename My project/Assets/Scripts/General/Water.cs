using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PlayerCharacter"))
        {
            other.GetComponent<PlayerCharacterHealth>().health = 0;
        }
        if(other.CompareTag("PlayerPlanetShip"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
