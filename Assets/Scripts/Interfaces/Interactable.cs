using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This interface is used by entities whom the player can interact with.
//It makes sure that the classes who implement it have an Interact() method
//that contains the Interaction itself.
public interface Interactable
{
    void Interact();
}
