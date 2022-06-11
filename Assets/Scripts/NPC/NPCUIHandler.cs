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
    }

    public void OnPlayerProximity()
    {
        DisplayName();
        DisplayInteractText();
    }

    public void OnPlayerAway()
    {
        HideName();
        HideInteractText();
    }



    private void DisplayName()
    {
        if (!nameTextIsActive)
        {
            nameTextIsActive = true;
            npcName.alpha = 255;
        }
    }

    private void HideName()
    {
        if (nameTextIsActive)
        {
            nameTextIsActive = false;
            npcName.alpha = 0;
        }
    }

    private void DisplayInteractText()
    {
        if (!interactTextIsActive)
        {
            interactTextIsActive = true;
            interactText.alpha = 255;
        }
    }

    private void HideInteractText()
    {
        if (interactTextIsActive)
        {
            interactTextIsActive = false;
            interactText.alpha = 0;
        }
    }
}
