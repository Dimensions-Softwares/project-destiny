using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IObservable<HealthBar>
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

    public HealthBar HealthBar => healthBar;

    private List<IObserver<HealthBar>> healthBarObservers;

    public void RegisterHealthBar(HealthBar healthBar)
    {
        if (InventoryManager != null)
        {
            Debug.LogWarning("Attempted to set Register Inventory but is already set.");
        }
        else
        {
            this.healthBar = healthBar;
            foreach (IObserver<HealthBar> healthBarObserver in healthBarObservers.ToArray())
            {
                healthBarObserver.OnNext(healthBar);
            }
            Debug.Log("Health Bar successfully registered.");
        }

    }

    public IDisposable Subscribe(IObserver<HealthBar> observer)
    {
        if (HealthBar != null && healthBarObservers.Contains(observer))
        {
            healthBarObservers.Add(observer);
        }

        return new HealthBarUnsubcriber(healthBarObservers, observer);
    }

    #endregion


    #region Player

    public event EventHandler playerProximityEnterEventHandler;
    public event EventHandler playerProximityExitEventHandler;

    public void onPlayerProximityEnterEvent(Interactable interaction)
    {
        EventHandler playerProxEnter = playerProximityEnterEventHandler;
        playerProxEnter(interaction, EventArgs.Empty);
    }

    public void onPlayerProximityExitEvent()
    {
        EventHandler playerProxExit = playerProximityExitEventHandler;
        playerProxExit(null, EventArgs.Empty);
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
        healthBarObservers = new List<IObserver<HealthBar>>();
    }

    #endregion

    
}
