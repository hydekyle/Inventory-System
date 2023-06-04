using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ClickItemMenu : MonoBehaviour
{
    [SerializeField] TMP_Text button1Text, priceValueText;
    [SerializeField] Button buttonUse, buttonSell;
    [SerializeField] RectTransform buttonsMenu;
    [SerializeField] GameObject panelParent;
    [SerializeField] InventoryUI inventoryUI;
    ItemUI selectedItemUI;

    public void ShowMenu(ItemUI itemUI)
    {
        selectedItemUI = itemUI;
        panelParent.SetActive(true);
        buttonsMenu.position = Input.mousePosition;
        if (selectedItemUI.item.GetType() == typeof(ItemWeapon))
        {
            button1Text.text = "EQUIP";
        }
        else
        {
            button1Text.text = "USE";
        }

        if (selectedItemUI.item.GetType() == typeof(ItemResource) || selectedItemUI.item.GetType() == typeof(ItemGarbage) || selectedItemUI.item.durability == 0)
        {
            buttonUse.interactable = false;
        }
        else
        {
            buttonUse.interactable = true;
        }

        var goldValue = selectedItemUI.item.GetGoldValue();
        if (goldValue > 0)
        {
            buttonSell.interactable = true;
            priceValueText.text = "x" + goldValue.ToString();
        }
        else
        {
            buttonSell.interactable = false;
            priceValueText.text = "";
        }
    }

    public void UseSelectedItem()
    {
        if (selectedItemUI.item.GetType() == typeof(ItemWeapon))
        {
            inventoryUI.playerController.EquipWeapon((ItemWeapon)selectedItemUI.item);
        }
        else if (selectedItemUI.item.GetType() == typeof(ItemConsumable))
        {
            //TODO: Implement logic for usable items
            print(String.Format("Item {0} has been used.", selectedItemUI.item.name));
            DiscardItem();
        }
        panelParent.SetActive(false);
    }

    public void DiscardItem()
    {
        selectedItemUI.ownerInventory.RemoveItem(selectedItemUI.item);
        if (selectedItemUI.item == inventoryUI.playerController.equipedWeapon)
        {
            inventoryUI.playerController.equipedWeapon = null;
            inventoryUI.equipmentUI.RefreshUI();
        }
        panelParent.SetActive(false);
    }

}
