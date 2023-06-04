using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Events;

public class InventoryUI : MonoBehaviour
{
    public RectTransform bagInventoryUI;
    public PlayerController playerController;
    public List<Item> availableRandomItemList;
    [SerializeField] GameObject itemUIPrefab;
    [SerializeField] TMP_Text bagWeightText;
    public EquipmentUI equipmentUI;
    public ClickItemMenu clickItemMenu;
    public UnityEvent onRefreshUI;

    void Start()
    {
        RefreshUI();
        playerController.inventory.onItemListChanged.AddListener(() => RefreshUI());
    }

    public void AddRandomItem()
    {
        var newItem = availableRandomItemList[UnityEngine.Random.Range(0, availableRandomItemList.Count)];
        playerController.inventory.AddItem(Instantiate(newItem));
    }

    void RefreshUI()
    {
        // TODO: Use Object Pool instead creating and destroying GameObject
        // since it generates work for the garbage collector
        foreach (Transform child in bagInventoryUI)
        {
            // We avoid removing the background image to be able to drag the inventory
            if (child.name != "Background")
            {
                Destroy(child.gameObject);
            }
        }
        playerController.inventory.itemList.ForEach(item =>
        {
            var newItemUI = GameObject.Instantiate(itemUIPrefab).GetComponent<ItemUI>();
            newItemUI.SetItemUI(item, playerController.inventory);
            newItemUI.ownerInventory = playerController.inventory;
            newItemUI.transform.SetParent(bagInventoryUI);
            newItemUI.itemButton.onClick.AddListener(() => clickItemMenu.ShowMenu(newItemUI));
        });
        bagWeightText.text = String.Format("{0}/{1}", playerController.inventory.weightTotal, playerController.inventory.weightMax);
        onRefreshUI.Invoke();
    }

    public void MakeTimePass()
    {
        playerController.inventory.itemList.ForEach(item =>
        {
            item.LoseDurability(5);
        });
        RefreshUI();
    }

}
