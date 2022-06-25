using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProximityEnterEventArgs : EventArgs
{
    public Interactable Interaction { get; protected set; }


    public PlayerProximityEnterEventArgs(Interactable _interaction)
    {
        Interaction = _interaction;
    }
}
