using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Scriptable Object containing sentences of a specific dialog

[CreateAssetMenu(menuName = "Dialog Object")]
public class DialogObject : ScriptableObject
{
    public List<string> linesList;
}
