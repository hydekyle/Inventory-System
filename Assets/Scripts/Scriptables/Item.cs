using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public abstract class Item : ScriptableObject, IDurability
{
    [ShowAssetPreview]
    public Sprite sprite;
    public new string name;
    [ResizableTextArea]
    public string description;
    public int weight;
    public int durabilityMax;
    public int durability;
    public int goldValue;
    [Tooltip("It will become the selected garbage when this item durability reachs 0")]
    public ItemGarbage itemGarbage;

    public void LoseDurability(int loseDurabilityAmount)
    {
        durability = Mathf.Clamp(durability - loseDurabilityAmount, 0, durabilityMax);
    }

    public void RepairDurability()
    {
        durability = durabilityMax;
    }

    public int GetGoldValue()
    {
        if (durability == 0) return 0;
        var durabilityPercent = durability * 100 / durabilityMax;
        return (goldValue * durabilityPercent) / 100;
    }
}
