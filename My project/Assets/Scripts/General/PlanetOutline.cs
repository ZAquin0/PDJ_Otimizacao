using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetOutline : MonoBehaviour
{
    [SerializeField] private SolarSystem solarSystem;
    [SerializeField] private PlayerInventory playerInventory;
    private void Start()
    {
        if(PlanetScene.isOutlineActive) AddOutiline();
        else RemoveOutline();
    }
    public void AddOutiline()
    {
        RemoveOutline();
        foreach(Item item in playerInventory.slots)
        {
            int index = 0;
            for(; item.destinationIndex != solarSystem.spaceObjects[index].id; index++);
            if(item.destinationIndex == solarSystem.spaceObjects[index].id)
                solarSystem.spaceObjects[index].outiline.gameObject.SetActive(true);
        }
    }
    public void RemoveOutline()
    {
        for(int index = 0; index <= 5; index++) 
            solarSystem.spaceObjects[index].outiline.gameObject.SetActive(false);
    }
}
