using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NPCUIHandler))]
[RequireComponent(typeof(NPCInteraction))]
public class NPCProximityTrigger : MonoBehaviour
{
    private NPCUIHandler uiHandler;
    private NPCInteraction NPCInteraction;
    // Start is called before the first frame update
    void Awake()
    {
        uiHandler = GetComponent<NPCUIHandler>();
        NPCInteraction = GetComponent<NPCInteraction>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(Constants.PLAYER_TAG))
        {
            EventAgregator.OnPlayerProximityEnter(gameObject, new PlayerProximityEnterEventArgs(NPCInteraction));
            uiHandler.OnPlayerProximity();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(Constants.PLAYER_TAG))
        {
            EventAgregator.OnPlayerProximityExit(gameObject, null);
            uiHandler.OnPlayerAway();
        }
    }
}
