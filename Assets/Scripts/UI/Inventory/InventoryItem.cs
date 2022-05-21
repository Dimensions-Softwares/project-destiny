using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class Describing the state of an inventory item
[Serializable]
public class InventoryItem
{
    public GameObject ItemSlotObject { get; private set; } //GameObject of the actual slot
    public InventoryItemData Data { get; private set; } //Scriptable Object of the Item
    public int StackSize { get; private set; } //Current Amount of Item owned by Player

    public InventoryItem(InventoryItemData source, GameObject itemSlotObject)
    {
        this.Data = source;
        this.ItemSlotObject = itemSlotObject;
    }

    public void AddToStack(int quantity)
    {
        if(StackSize + quantity > Constants.MAX_ITEM_STACK_SIZE)
        {
            Debug.LogError($"Increased Stack Size Over Maximum for Item {Data.displayName} (Tried to have {StackSize + quantity})");
            StackSize = Constants.MAX_ITEM_STACK_SIZE;
        } else
        {
            StackSize += quantity;
        }
    }

    public void RemoveFromStack(int quantity)
    {
        if (StackSize - quantity < 0)
        {
            Debug.LogError($"Not enough stack for Collectible : {Data.displayName} (Current value is {StackSize}, attempted to remove {quantity})");
        } else
        {
            StackSize -= quantity;
        }
    }

}
