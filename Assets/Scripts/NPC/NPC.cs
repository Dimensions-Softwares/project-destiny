using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is the class that describes the NPC Game Object data
//It uses the NPCData Scriptable Object to initialize the NPC informations
//For the moment it only has the sprite and name

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(NPCUIHandler))]
public class NPC : MonoBehaviour
{
    [SerializeField] private NPCData data;

    void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = data.Sprite;
        GetComponent<NPCUIHandler>().SetName(data.NPCName);
    }
}
