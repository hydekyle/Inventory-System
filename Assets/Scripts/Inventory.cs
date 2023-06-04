using System.Collections.Generic;
using System;
using UnityEngine.Events;
using UnityEngine;

[Serializable]
public class Inventory
{
    public int weightMax;
    public List<Item> itemList;
    [HideInInspector]
    public UnityEvent onItemListChanged;
    [HideInInspector]
    public int weightTotal;

    public void AddItem(Item item)
    {
        if (weightTotal + item.weight > weightMax)
        {
            Debug.Log("Your bag is full! You can't carry this item.");
            return;
        }
        itemList.Add(item);
        weightTotal += item.weight;
        onItemListChanged.Invoke();
    }

    public void RemoveItem(Item item)
    {
        itemList.Remove(item);
        weightTotal -= item.weight;
        onItemListChanged.Invoke();
    }

}
