using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DepositAreaHUD : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;
    public void Deposit()
    {
        for(int index = 0; index < playerInventory.slots.Count; index++)
        {
            if(playerInventory.slots[index].destinationIndex == PlanetScene.planetIndex)
            {
                //Debug.Log($"Depositing Item: {playerInventory.slots[index].name}");
                PlanetScene.currentMoney += playerInventory.slots[index].value;
                playerInventory.RemoveItem(index--);
            }
        }
    }
}
