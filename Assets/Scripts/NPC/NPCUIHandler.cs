using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//Class that handles UI elements around NPC, like the name and the dialog icon
public class NPCUIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshPro npcName;
    private bool nameTextIsActive;


    [SerializeField] private GameObject interactIcon;
    private bool interactIconIsActive;

    private void Start()
    {
        HideName();
        HideInteractIcon();
    }

    public void OnPlayerProximity()
    {
        if (!nameTextIsActive)
        {
            DisplayName();
        }
        if (!interactIconIsActive)
        {
            DisplayInteractIcon();
        }
    }

    public void OnPlayerAway()
    {
        if (nameTextIsActive)
        {
            HideName();
        }
        if (interactIconIsActive)
        {
            HideInteractIcon();
        }
    }



    private void DisplayName()
    {
        nameTextIsActive = true;
        npcName.alpha = 255;
        
    }

    private void HideName()
    {
        nameTextIsActive = false;
        npcName.alpha = 0;
    }

    private void DisplayInteractIcon()
    {
        interactIconIsActive = true;
        interactIcon.SetActive(true);
        
    }

    private void HideInteractIcon()
    {
        interactIconIsActive = false;
        interactIcon.SetActive(false);
    }

    public void SetName(string name)
    {
        npcName.text = name;
    }
}
