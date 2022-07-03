using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventAgregator
{
    #region Proximity Trigger

    public static event EventHandler<PlayerProximityEnterEventArgs> PlayerProximityEnterEvent;

    public static void OnPlayerProximityEnter(GameObject sender, PlayerProximityEnterEventArgs args)
    {
        EventHandler<PlayerProximityEnterEventArgs> tempEvent = PlayerProximityEnterEvent;
        tempEvent(sender, args);
    }

    public static event EventHandler PlayerProximityExitEvent;

    public static void OnPlayerProximityExit(GameObject sender, EventArgs args)
    {
        EventHandler tempEvent = PlayerProximityExitEvent;
        tempEvent(sender, args);
    }

    #endregion

    #region Interaction

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

    public static event EventHandler InventoryRegisteredEvent;

    public static void OnInventoryRegistered(GameObject sender, EventArgs args)
    {
        EventHandler tempEvent = InventoryRegisteredEvent;
        tempEvent(sender, args);
    }

    #endregion
}
