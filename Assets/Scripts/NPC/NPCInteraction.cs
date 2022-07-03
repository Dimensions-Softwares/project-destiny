using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class describing NPC Interaction.
//Implements Interactable to make sure it has a Interact() method.
//For the moment the only possible interactions are dialogs.
public class NPCInteraction : MonoBehaviour,Interactable
{
    [SerializeField] private DialogObject dialog; //Scriptable Object containing dialogue sentences
    public void Interact()
    {
        DialogBoxFactory.InstantiateDialogBox(GameManager.Instance.DialogBoxPrefab, dialog);
    }
}
