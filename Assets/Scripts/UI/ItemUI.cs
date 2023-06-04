using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [SerializeField] Image itemSprite;
    [SerializeField] TMP_Text durationText;
    public Inventory ownerInventory;
    public Button itemButton;
    public Item item;

    public void SetItemUI(Item item, Inventory ownerInventory)
    {
        this.item = item;
        this.ownerInventory = ownerInventory;
        itemSprite.sprite = item.durability > 0 ? item.sprite : item.itemGarbage.sprite;
        durationText.text = String.Format("{0}/{1}", item.durability, item.durabilityMax);
    }
}
