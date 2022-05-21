using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryManager : MonoBehaviour
{

    [SerializeField] private InventoryUI inventoryUI; //Reference to the UI
    private static Inventory inventory; //Actual Inventory

    // Start is called before the first frame update
    private void Awake()
    {
        InitializeInventory();
    }

    private void Start()
    {
        GameManager.Instance.RegisterInventory(this); //Register itself to the GameManager
    }

    void Update()
    {
        if (Input.GetButtonUp(Inputs.INVENTORY_BUTTON))
        {
            ToggleInventory();
        }
    }

    private void InitializeInventory()
    {
        inventory = new Inventory();
    }

    public void AddItem(InventoryItemData itemData, int quantity = 1)
    {
        inventory.Add(itemData, quantity);
    }
    public void RemoveItem(InventoryItemData itemData, int quantity = 1)
    {
        inventory.Remove(itemData, quantity);
    }

    internal void ToggleInventory()
    {
        inventoryUI.ToggleInventory();
    }

    internal InventoryItem Register(GameObject itemSlotObject, InventoryItemData itemData)
    {
        return inventory.Register(itemSlotObject, itemData); //Receive Registering from Inventory Slots
    }

    public bool IsActive()
    {
        return inventoryUI.gameObject.activeSelf;
    }
}
