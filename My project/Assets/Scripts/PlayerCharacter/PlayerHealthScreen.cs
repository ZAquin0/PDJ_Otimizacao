using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthScreen : MonoBehaviour
{
    [SerializeField] private Material bloodyScreen;
    [SerializeField] private PlayerCharacterHealth health;
    private void Update()
    {
        Color color = bloodyScreen.color;
        color.a = Mathf.InverseLerp(health.maxHealth, 1, health.health);
        bloodyScreen.color = color;
    }
}
