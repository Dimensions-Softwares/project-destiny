using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Interactable currentInteraction = null;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.playerProximityEnterEventHandler += PlayerProximityEnterEvent;
        GameManager.Instance.playerProximityExitEventHandler += PlayerProximityExitEvent;
    }

    private void PlayerProximityEnterEvent(object sender, EventArgs args)
    {
        if(currentInteraction != null)
        {
            Debug.LogError("Overlap of interactions.");
        } 
        else if (!(sender is Interactable))
        {
            Debug.LogError("Interaction is not implementing Interactable.");
        } 
        else
        {
            currentInteraction = (Interactable) sender;
        }
    }

    private void PlayerProximityExitEvent(object sender, EventArgs args)
    {
        if (currentInteraction == null)
        {
            Debug.LogError("Interaction is null but Exit triggered.");
        }
        else
        {
            currentInteraction = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown(Inputs.INTERACT_BUTTON) && currentInteraction != null)
        {
            currentInteraction.Interact();
        }
    }
}
