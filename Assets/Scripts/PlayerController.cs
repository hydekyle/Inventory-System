using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public Inventory inventory;
    public ItemWeapon equipedWeapon;
    [HideInInspector]
    public UnityEvent onEquipedWeaponChanged;

    public void Attack()
    {
        if (equipedWeapon == null)
        {
            print("You need to equip a weapon to attack.");
            return;
        }

        if (equipedWeapon.consumesItemToUse)
        {
            var requiredItemInInventory = inventory.itemList.Find(item => item.name == equipedWeapon.requiredItemToUse.name);
            if (requiredItemInInventory == null)
            {
                print(String.Format("You need {0} to use this weapon", equipedWeapon.requiredItemToUse.name));
                return;
            }
            inventory.RemoveItem(requiredItemInInventory);
        }

        equipedWeapon.LoseDurability(2); // Weapon loses 2 durability points when attack
        inventory.onItemListChanged.Invoke();
    }

    public void EquipWeapon(ItemWeapon weapon)
    {
        equipedWeapon = weapon;
        onEquipedWeaponChanged.Invoke();
    }

    public void UnequipWeapon()
    {
        equipedWeapon = null;
        onEquipedWeaponChanged.Invoke();
    }
}
