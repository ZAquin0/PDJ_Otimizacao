using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlanetScene
{
    public static int planetIndex = -1;
    public static float currentFuel = 7500;
    public static float currentJetpackFuel = 500;
    public static int currentMoney = 500;
    public static int maxInventoryCapacity = 100;
    public static List<Item>? inventorySlots = null;
    public static bool isSunResistant = false;
    public static bool isOutlineActive = false;
    public static bool[] planetPuzzleSolved = new bool[6];
    public static float currentSpeedThreshold = 20;
    public static void ResetValues()
    {
        planetIndex = -1;
        currentFuel = 7500;
        currentJetpackFuel = 500;
        currentMoney = 500;
        maxInventoryCapacity = 100;
        inventorySlots = null;
        isSunResistant = false;
        isOutlineActive = false;
        planetPuzzleSolved = new bool[6];
    }
}
