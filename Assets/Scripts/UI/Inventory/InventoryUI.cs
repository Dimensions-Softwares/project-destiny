using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryUI : MonoBehaviour
{

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OpenInventory()
    {
        gameObject.SetActive(true);
    }

    private void CloseInventory()
    {
        gameObject.SetActive(false);
    }

    public void ToggleInventory()
    {
        if (gameObject.activeSelf)
        {
            CloseInventory();
        }
        else
        {
            OpenInventory();
        }
    }

    //When the stack of an item falls to zero
    internal void DisableItem(GameObject itemObject)
    {
        itemObject.GetComponent<InventorySlotHandler>().DisableItem();
    }
}
