using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTSetCurrentScene : MonoBehaviour
{
    [SerializeField] private int scene;
    private void Start() => PlanetScene.planetIndex = scene;
}
