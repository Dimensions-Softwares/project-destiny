using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryManager : MonoBehaviour
{

    [SerializeField] private InventoryUI inventoryUI; //Reference to the UI
    private static Inventory inventory; //Actual Inventory

    private bool isPlayerInteracting;

    // Start is called before the first frame update
    private void Awake()
    {
        InitializeInventory();
        RegisterEvents();
    }

    private void RegisterEvents()
    {
        EventAgregator.PlayerInteractionStartEvent += OnPlayerInteractionStart;
        EventAgregator.PlayerInteractionEndEvent += OnPlayerInteractionEnd;
    }

    private void Start()
    {
        isPlayerInteracting = false;
        GameManager.Instance.RegisterInventory(this); //Register itself to the GameManager
        EventAgregator.OnInventoryRegistered(null, EventArgs.Empty);
    }

    void Update()
    {
        if (Input.GetButtonUp(Inputs.INVENTORY_BUTTON) && CanOpenInventory())
        {
            ToggleInventory();
        }
    }

    private bool CanOpenInventory()
    {
        return !isPlayerInteracting;
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

    private void OnPlayerInteractionStart(object sender, EventArgs args)
    {
        isPlayerInteracting = true;
    }

    private void OnPlayerInteractionEnd(object sender, EventArgs args)
    {
        isPlayerInteracting = false;
    }
}
