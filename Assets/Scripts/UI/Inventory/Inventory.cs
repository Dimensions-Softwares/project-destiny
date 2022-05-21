using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class managing the actual inventory data of the player
public class Inventory
{
    private readonly Dictionary<InventoryItemData, InventoryItem> itemDictionary; //Dictionary Associating an Item (Scriptable Object)
                                                                                  //to the item instance in the inventory (InventoryItem)


    public Inventory()
    {
        itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
    }


    //Allows an item slot to notify its existence to the inventory, so that the inventory adds the item to the dictionary
    public InventoryItem Register(GameObject itemSlotObject, InventoryItemData itemData)
    {
        InventoryItem newItem = new InventoryItem(itemData, itemSlotObject);
        itemDictionary.Add(itemData, newItem);
        return newItem;
    }


    public InventoryItem Get(InventoryItemData referenceData)
    {
        if(itemDictionary.TryGetValue(referenceData, out InventoryItem value) ) 
        {
            return value;
        }
        else
        {
            Debug.LogError("Collectible doesn't exist.");
            return null;
        }
    }

    public void Add(InventoryItemData newItemData, int quantity)
    {
        InventoryItem item = Get(newItemData);
        item.AddToStack(quantity);
    }

    public void Remove(InventoryItemData itemData, int quantity)
    {
        InventoryItem item = Get(itemData);
        item.RemoveFromStack(quantity);
        if(item.StackSize == 0)
        {
            item.ItemSlotObject.GetComponent<InventorySlotHandler>().DisableItem();
        }
    }
}
