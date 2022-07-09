using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Scriptable Object containing basic info about NPC

[CreateAssetMenu(menuName = "NPC/NPC Data")]
public class NPCData : ScriptableObject
{
    public string NPCName;

    public Sprite Sprite;
}
