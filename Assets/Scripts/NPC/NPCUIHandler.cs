using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCUIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshPro npcName;
    private bool nameTextIsActive;


    [SerializeField] private TextMeshPro interactText;
    private bool interactTextIsActive;

    private void Start()
    {
        HideName();
        HideInteractText();
    }

    public void OnPlayerProximity()
    {
        if (!nameTextIsActive)
        {
            DisplayName();
        }
        if (!interactTextIsActive)
        {
            DisplayInteractText();
        }
    }

    public void OnPlayerAway()
    {
        if (nameTextIsActive)
        {
            HideName();
        }
        if (interactTextIsActive)
        {
            HideInteractText();
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

    private void DisplayInteractText()
    {
        interactTextIsActive = true;
        interactText.alpha = 255;
        
    }

    private void HideInteractText()
    {
        interactTextIsActive = false;
        interactText.alpha = 0;
    }

    public void SetName(string name)
    {
        npcName.text = name;
    }
}
