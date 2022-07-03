using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Factory Pattern used to instantiate Dialog Boxes
public static class DialogBoxFactory
{
    public static Object InstantiateDialogBox(Object dialogObj, DialogObject dialog)
    {
        GameObject dialogBox = Object.Instantiate(dialogObj) as GameObject;
        dialogBox.GetComponent<DialogManager>().SetDialogObject(dialog);
        return dialogBox;
    }
}
