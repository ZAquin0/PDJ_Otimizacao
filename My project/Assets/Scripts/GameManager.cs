using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public GameManager instance {get; private set;}
    [SerializeField] private float playTimeSpeed = 1;
    private void Awake()
    {
        if(instance != null && instance != this) Destroy(this);
        else instance = this;
    }
    private void Start()
    {
        Time.timeScale = playTimeSpeed;
    }
}
