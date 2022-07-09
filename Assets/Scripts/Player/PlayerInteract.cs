using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script that manages the interaction available to the player
public class PlayerInteract : MonoBehaviour
{
    private Interactable currentInteraction = null; // The current interaction that will be triggered
                                                    // if the player presses the interact button
    public bool IsInteracting { get; private set; } // Public property to allow other scripts to check if the player is interacting

    void Start()
    {
        IsInteracting = false;
        RegisterEvents();
    }

    private void RegisterEvents()
    {
        #region Proximity
        EventAgregator.PlayerProximityEnterEvent += OnPlayerProximityEnter;
        EventAgregator.PlayerProximityExitEvent += OnPlayerProximityExit;
        #endregion

        #region Interaction
        EventAgregator.PlayerInteractionEndEvent += OnPlayerInteractionEnd;
        EventAgregator.PlayerInteractionStartEvent += OnPlayerInteractionStart;
        #endregion
    }

    // When the player is near enough an interactable entity
    private void OnPlayerProximityEnter(object sender, PlayerProximityEnterEventArgs args)
    {
        
        if(currentInteraction != null)
        {
            Debug.LogError("Overlap of interactions.");
        } 
        else if (args.Interaction == null)
        {
            Debug.LogError("Incoming interaction is null.");
        } 
        else
        {
            currentInteraction = args.Interaction; //We set the current interaction to this one
        }
    }

    private void OnPlayerProximityExit(object sender, EventArgs args)
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

    private void OnPlayerInteractionStart(object sender, EventArgs args)
    {
        IsInteracting = true;
    }

    private void OnPlayerInteractionEnd(object sender, EventArgs args)
    {
        IsInteracting = false;
    }

    private bool CanInteract()
    {
        return currentInteraction != null && !IsInteracting && !GameManager.Instance.InventoryManager.IsActive();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown(Inputs.INTERACT_BUTTON) && CanInteract())
        {
            currentInteraction.Interact(); //Trigger the interaction
        }
    }
}
