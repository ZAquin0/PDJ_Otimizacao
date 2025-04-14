using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[Serializable]
public struct Item
{
    public string name;
    public Color itemImage;
    public int weight;
    public int destinationIndex;
    public int value;
    public Sprite missionDificulty;
    public float missionTime;
}
public class ItemLibrary : MonoBehaviour
{
    [HideInInspector] public static ItemLibrary instance {get; private set;}
    public Item[] items;
    private void Awake()
    {
        if(instance != null && instance != this) Destroy(this);
        else instance = this;
    }
    public Item GetRandomItem()
    {
        int randomItem = UnityEngine.Random.Range(0, items.Length);
        return items[randomItem];
    }
    public Item? GetItem(string name)
    {
        Item? answer = null;
        foreach(Item item in items)
        {
            if(name == item.name) 
            {
                answer = item;
                break;
            }
        }
        return answer;
    }
}
