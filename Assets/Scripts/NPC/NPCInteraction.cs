using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour,Interactable
{
    [SerializeField] private DialogObject dialog;
    public void Interact()
    {
        DialogBoxFactory.InstantiateDialogBox(GameManager.Instance.dialogBoxPrefab, dialog);
    }
}
