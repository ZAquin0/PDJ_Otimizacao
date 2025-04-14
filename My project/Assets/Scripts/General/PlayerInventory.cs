using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class PlayerInventory : MonoBehaviour
{
    public List<Item> slots;
    public int maxInventoryCapacity;
    public static int currentInventoryCapacity = 0;
    private void Awake()
    {
        maxInventoryCapacity = PlanetScene.maxInventoryCapacity;
        if (PlanetScene.inventorySlots is List<Item> savedSlots) slots = savedSlots;
        else PlanetScene.inventorySlots = slots;
    }
    private void Update()
    {
        if (currentInventoryCapacity > maxInventoryCapacity) currentInventoryCapacity = maxInventoryCapacity;
        if (slots.Count > 0) PlanetScene.isOutlineActive = true;
        else PlanetScene.isOutlineActive = false;
    }
    public bool AddItem(Item item)
    {
        if (currentInventoryCapacity + item.weight <= maxInventoryCapacity)
        {
            slots.Add(item);
            currentInventoryCapacity += item.weight;
            return true;
        }
        else Debug.Log("Cannot add more items");
        return false;
    }
    public Item RemoveItem(int position)
    {
        Item removedItem = slots[position];
        currentInventoryCapacity -= removedItem.weight;
        slots.RemoveAt(position);
        return removedItem;
    }
    public void OrganizeInventoryByWeight()
    {
        QuickSort(0, slots.Count - 1);
    }

    private void QuickSort(int low, int high)
    {
        if (low < high)
        {
            int partitionIndex = Partition(low, high);
            QuickSort(low, partitionIndex - 1);
            QuickSort(partitionIndex + 1, high);
        }
    }

    private int Partition(int low, int high)
    {
        int pivot = slots[high].weight;
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (slots[j].weight >= pivot)
            {
                i++;
                SwapItems(i, j);
            }
        }

        SwapItems(i + 1, high);
        return i + 1;
    }

    private void SwapItems(int i, int j)
    {
        Item temp = slots[i];
        slots[i] = slots[j];
        slots[j] = temp;
    }
}