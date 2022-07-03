using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Instance definition
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Game Manager is null.");
            }
            return _instance;
        }
    }
    #endregion


    #region Inventory

    private InventoryManager inventoryManager;
    public InventoryManager InventoryManager { get => inventoryManager; private set => inventoryManager = value; }


    //Method to register the reference to the Inventory Manager so that other scritps can access it
    public void RegisterInventory(InventoryManager inventory)
    {
        if (InventoryManager != null)
        {
            Debug.LogWarning("Attempted to set Register Inventory but is already set.");
        }
        else
        {
            InventoryManager = inventory;
            Debug.Log("Inventory successfully registered.");
        }
    }

    #endregion


    #region Health Bar

    private HealthBar healthBar;

    public HealthBar HealthBar { get => healthBar; private set => healthBar = value; }

    public void RegisterHealthBar(HealthBar healthBar)
    {
        if (HealthBar != null)
        {
            Debug.LogWarning("Attempted to set Health Bar but is already set.");
        }
        else
        {
            HealthBar = healthBar;
            EventAgregator.OnHealthBarRegistered(null, EventArgs.Empty);
            Debug.Log("Health Bar successfully registered.");
        }
    }

    #endregion





    #region Dialog
    [SerializeField] private GameObject dialogBoxPrefab;

    public GameObject DialogBoxPrefab { get => dialogBoxPrefab; private set => dialogBoxPrefab = value; }
    #endregion


    #region Main

    private void Awake()
    {
        _instance = this; //Init of Game manager
        DontDestroyOnLoad(gameObject); //So that the GameManager is persistent between scenes
    }

    #endregion

    
}
