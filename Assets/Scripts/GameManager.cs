using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IObservable<InventoryManager>
{
    List<IObserver<InventoryManager>> inventoryObservers; //To notify Inventory Slots that Inventory is ready

    private static GameManager _instance;

    private InventoryManager inventoryManager;
    public InventoryManager InventoryManager { get => inventoryManager; private set => inventoryManager = value; }
    
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("Game Manager is null.");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this; //Init of Game manager
        DontDestroyOnLoad(gameObject); //So that the GameManager is persistent between scenes
        inventoryObservers = new List<IObserver<InventoryManager>>(); //Initialization of Observer for Inventory Manager
    }

    //Method to register the reference to the Inventory Manager so that other scritps can access it
    public void RegisterInventory(InventoryManager inventory)
    {
        if(InventoryManager != null)
        {
            Debug.LogWarning("Attempted to set Register Inventory but is already set.");
        }
        else
        {
            InventoryManager = inventory;
            foreach (var observer in inventoryObservers.ToArray()) //ToArray() in order to copy the list so it's not modified by OnCompleted()
            {
                observer.OnCompleted(); //Notify the observers that the inventory is finally registered
            }
            Debug.Log("Inventory successfully registered.");
        }
    }

    //Method to allow observers to subscribe to the event of Inventory Registering
    public IDisposable Subscribe(IObserver<InventoryManager> observer)
    {
        if(InventoryManager == null && !inventoryObservers.Contains(observer))
        {
            inventoryObservers.Add(observer);
        }

        return new InventoryUnsubscriber<InventoryManager>(inventoryObservers, observer);
    }
}
