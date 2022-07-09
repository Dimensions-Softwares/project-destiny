using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is a custom EventArgs used for Proximity Events
//It contains the Interactable interface given by the entity
//The player is close to.
public class PlayerProximityEnterEventArgs : EventArgs
{
    public Interactable Interaction { get; protected set; }


    public PlayerProximityEnterEventArgs(Interactable _interaction)
    {
        Interaction = _interaction;
    }
}
