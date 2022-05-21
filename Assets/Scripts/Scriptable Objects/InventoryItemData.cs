using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Scriptable Object describing an Item
[CreateAssetMenu(menuName = "Inventory Item")]
public class InventoryItemData : ScriptableObject
{
    public string id;
    public string displayName;
    public Sprite icon;
    public Sprite emptyIcon;
    public int maxStackNumber;
    public string description;
}
