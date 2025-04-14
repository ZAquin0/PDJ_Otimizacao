using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatCode : MonoBehaviour
{
    private bool isInvincible = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!isInvincible)
            {
                PlanetScene.currentSpeedThreshold = 1000;
                isInvincible = true;
            }
            else
            {
                PlanetScene.currentSpeedThreshold = 20;
                isInvincible = false;
            }
        }
    }
}
