using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Upgrade
{
    public string name;
    public int id;
    public Color upgradeImage;
    public int planetIndex;
    public float acceleration;
    public float maxVelocity;
    public float fuelConsumptionRate;
    public int maxItemCapacity;
}
public class UpgradeLibrary : MonoBehaviour
{
    [SerializeField] private Upgrade[] upgrades;
}
