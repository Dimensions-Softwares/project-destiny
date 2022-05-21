using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


//UI Class that handles the Slot of an Item
public class InventorySlotHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IObserver<InventoryManager>
{
    
    [SerializeField] private Image slotIcon; //Icon of the object
    [SerializeField] private TextMeshProUGUI slotItemNameText; //Name
    [SerializeField] private TextMeshProUGUI stackSizeText; //Stack Number
    [SerializeField] private InventoryItemData itemData; //Scriptable Object of the Item
    [SerializeField] private GameObject itemInfoBox; //The GameObject of the InfoBox displaying the name

    private InventoryItem inventoryItem;
    private IDisposable observationResponse; //For unsubscribing to the event of Inventory Manager Registering to Game Manager

    public InventoryItemData ItemData
    {
        get => itemData;

        private set => itemData = value;
    }

    private void OnEnable()
    {
        HideInfoBox(); //Avoiding bugs where the info box is showing even though the mouse doesn't hover the item
    }

    private void Start()
    {
        if (GameManager.Instance.InventoryManager != null) //If the Inventory Manager has registered to the Game Manager :
        {
            RegisterToInventory();
        }
        else //Else, we subscribe to the event to be notified once that happens
        {
            observationResponse = GameManager.Instance.Subscribe(this);
        }
    }
    public void SetItem(InventoryItemData itemData)
    {
        try
        {
            this.itemData = itemData;
            slotIcon.sprite = inventoryItem.StackSize > 0 ? itemData.icon : itemData.emptyIcon;
            slotItemNameText.text = itemData.displayName;
            stackSizeText.text = "3"; // Temporary
        } catch (NullReferenceException)
        {
            Debug.LogError("Null item passed in Inventory Slot.");
        }
    }

    internal void DisableItem()
    {
        slotIcon.sprite = itemData.emptyIcon; //Set the sprite icon to the shadowed sprite if stack is zero
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        DisplayInfoBox();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HideInfoBox();
    }

    private void HideInfoBox()
    {
        itemInfoBox.SetActive(false);
    }

    private void DisplayInfoBox()
    {
        itemInfoBox.SetActive(true);
    }

    public void OnCompleted() //When the Inventory Manager has finally registered
    {
        RegisterToInventory();

        if (itemData != null)
        {
            SetItem(itemData); //We then can initialize the Slot with the correct informations of the item
        }
        else
        {
            Debug.LogError("Item Slot initiliazed without Item Data.");
        }
        
        observationResponse.Dispose(); //Unsubscribe to stop receiving notification
    }

    private void RegisterToInventory()
    {
        inventoryItem = GameManager.Instance.InventoryManager.Register(gameObject, itemData); //Registering to the Inventory
    }


    //Not used, but needed to implement
    void IObserver<InventoryManager>.OnError(Exception error) {}

    void IObserver<InventoryManager>.OnNext(InventoryManager value) {}
}
