using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EquipmentUI : MonoBehaviour
{
    [SerializeField] TMP_Text weaponName, weaponDurability, weaponDamage;
    [SerializeField] Image weaponIcon;
    [SerializeField] PlayerController playerController;
    [SerializeField] InventoryUI inventoryUI;

    void Start()
    {
        playerController.onEquipedWeaponChanged.AddListener(() => RefreshUI());
        inventoryUI.onRefreshUI.AddListener(() => RefreshUI());
    }

    public void RefreshUI()
    {
        if (playerController.equipedWeapon != null)
        {
            if (playerController.equipedWeapon.durability == 0)
            {
                playerController.UnequipWeapon();
                return;
            }

            weaponName.text = playerController.equipedWeapon.name;
            weaponDamage.text = playerController.equipedWeapon.attackPower.ToString();
            weaponDurability.text = playerController.equipedWeapon.durability.ToString();
            weaponIcon.sprite = playerController.equipedWeapon.sprite;
            weaponIcon.color = new Color(255, 255, 255, 255);
        }
        else
        {
            weaponName.text = "";
            weaponDurability.text = "";
            weaponDamage.text = "";
            weaponIcon.color = new Color(255, 255, 255, 0);
        }

    }
}
