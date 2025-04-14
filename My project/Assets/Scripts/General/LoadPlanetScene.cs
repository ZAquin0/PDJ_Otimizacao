using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadPlanetScene : MonoBehaviour
{
    private enum Planet { Planet1, Planet2, Planet3, Planet4, Planet5, Sun, Space };
    [Header("Scene")]
    [SerializeField] private Planet planet;
    [SerializeField] private Color transitionColor;
    [Header("Dependency")]
    [SerializeField] private LoadingScreen loadingScreen;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerSpaceShip") || other.CompareTag("PlayerPlanetShip"))
        {
            if (planet == Planet.Planet1)
            {
                other.GetComponent<PlayerShipHealth>().enabled = false;
                PlanetScene.currentFuel = other.GetComponent<PlayerShipMovement>().currentFuel;
                PlanetScene.planetIndex = 1;
                StartCoroutine(loadingScreen.LoadLevel("Planet 1", transitionColor));
            }
            else if (planet == Planet.Planet2)
            {
                other.GetComponent<PlayerShipHealth>().enabled = false;
                PlanetScene.currentFuel = other.GetComponent<PlayerShipMovement>().currentFuel;
                PlanetScene.planetIndex = 2;
                StartCoroutine(loadingScreen.LoadLevel("Planet 2", transitionColor));
            }
            else if (planet == Planet.Planet3)
            {
                other.GetComponent<PlayerShipHealth>().enabled = false;
                PlanetScene.currentFuel = other.GetComponent<PlayerShipMovement>().currentFuel;
                PlanetScene.planetIndex = 3;
                StartCoroutine(loadingScreen.LoadLevel("Planet 3", transitionColor));
            }
            else if (planet == Planet.Planet4)
            {
                other.GetComponent<PlayerShipHealth>().enabled = false;
                PlanetScene.currentFuel = other.GetComponent<PlayerShipMovement>().currentFuel;
                PlanetScene.planetIndex = 4;
                StartCoroutine(loadingScreen.LoadLevel("Planet 4", transitionColor));
            }
            else if (planet == Planet.Planet5)
            {
                other.GetComponent<PlayerShipHealth>().enabled = false;
                PlanetScene.currentFuel = other.GetComponent<PlayerShipMovement>().currentFuel;
                PlanetScene.planetIndex = 5;
                StartCoroutine(loadingScreen.LoadLevel("Planet Test", transitionColor));
            }
            else if (planet == Planet.Sun && PlanetScene.isSunResistant)
            {
                other.GetComponent<PlayerShipHealth>().enabled = false;
                PlanetScene.currentFuel = other.GetComponent<PlayerShipMovement>().currentFuel;
                PlanetScene.planetIndex = 0;
                StartCoroutine(loadingScreen.LoadLevel("Sun", transitionColor));
            }
            else if (planet == Planet.Space)
            {
                StartCoroutine(loadingScreen.LoadLevel("Space", transitionColor));
            }
        }
    }
}