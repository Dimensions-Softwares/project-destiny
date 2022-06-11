using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NPCUIHandler))]
public class NPCProximityTrigger : MonoBehaviour
{
    private NPCUIHandler uiHandler;
    // Start is called before the first frame update
    void Awake()
    {
        uiHandler = GetComponent<NPCUIHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(Constants.PLAYER_TAG))
        {
            uiHandler.OnPlayerProximity();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(Constants.PLAYER_TAG))
        {
            uiHandler.OnPlayerAway();
        }
    }
}
