using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(NPCUIHandler))]
public class NPC : MonoBehaviour
{
    [SerializeField] private NPCData data;
    private SpriteRenderer spriteRenderer;
    private NPCUIHandler uiHandler;
    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        uiHandler = GetComponent<NPCUIHandler>();
        spriteRenderer.sprite = data.Sprite;
        uiHandler.SetName(data.NPCName);
    }
}
