using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This the class for subscribing to and triggering any event occuring in the game.
public static class EventAgregator
{
    #region Player Proximity Trigger

    //Triggered when the player is near an interactable entity (NPC, Door, Button...)
    //For the moment it is implemented only for NPCs (but easily generalizable)
    public static event EventHandler<PlayerProximityEnterEventArgs> PlayerProximityEnterEvent;

    //Method to actually trigger the event
    public static void OnPlayerProximityEnter(GameObject sender, PlayerProximityEnterEventArgs args)
    {
        //We make a copy of the event to make sure the subcribers list is constant
        EventHandler<PlayerProximityEnterEventArgs> tempEvent = PlayerProximityEnterEvent;
        tempEvent(sender, args); //Trigger the event
    }

    //When the player exits the interactable area of an entity
    public static event EventHandler PlayerProximityExitEvent;
    
    public static void OnPlayerProximityExit(GameObject sender, EventArgs args)
    {
        EventHandler tempEvent = PlayerProximityExitEvent;
        tempEvent(sender, args);
    }

    #endregion

    #region Player Interaction

    //Triggered when the player start/end an interaction with an entity
    //Usually used to prevent the player from doing certain actions during
    //the interaction, like moving, opening the menu/inventory...


    public static event EventHandler PlayerInteractionStartEvent;

    public static void OnPlayerInteractionStart(GameObject sender, EventArgs args)
    {
        EventHandler tempEvent = PlayerInteractionStartEvent;
        tempEvent(sender, args);
    }

    public static event EventHandler PlayerInteractionEndEvent;

    public static void OnPlayerInteractionEnd(GameObject sender, EventArgs args)
    {
        EventHandler tempEvent = PlayerInteractionEndEvent;
        tempEvent(sender, args);
    }

    #endregion

    #region Inventory

    //Triggered when the inventory has registered to the GameManager, to prevent
    //bad initialization due to components trying to access inventory while it hasn't
    //registered yet.


    public static event EventHandler InventoryRegisteredEvent;

    public static void OnInventoryRegistered(GameObject sender, EventArgs args)
    {
        EventHandler tempEvent = InventoryRegisteredEvent;
        tempEvent(sender, args);
    }

    #endregion

    #region Health Bar

    //Same as Inventory

    public static event EventHandler HealthBarRegisteredEvent;

    public static void OnHealthBarRegistered(object sender, EventArgs args)
    {
        if(HealthBarRegisteredEvent != null)
        {
            EventHandler tempEvent = HealthBarRegisteredEvent;
            tempEvent(sender, args);
        }
    }

    #endregion
}
