using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class that manages the lifecycle of the dialog box.

public class DialogManager : MonoBehaviour
{
    private DialogObject dialog; //The sentences to display
    [SerializeField] private DialogTextManager textManager; //The script that actually display the lines
    private List<string> dialogLines; //Copy of the lines
    void Start()
    {
        dialogLines = new List<string>(dialog.linesList);
        EventAgregator.OnPlayerInteractionStart(gameObject, null); //Notify Components that an interaction started
        DisplayNextLine();
    }

    void Update()
    {
        if (Input.GetButtonDown(Inputs.INTERACT_BUTTON) && !textManager.IsDisplayingLine)
        {
            if (dialogLines.Count > 0)
            {
                DisplayNextLine();
            }
            else
            {
                CloseDialogBox();
            }
        }
    }

    private void DisplayNextLine()
    {
        StartCoroutine(textManager.DisplayLine(dialogLines[0]));
        dialogLines.RemoveAt(0); //To make sure we don't display the same line
    }

    public void SetDialogObject(DialogObject dialogObject)
    {
        dialog = dialogObject;
    }

    private void CloseDialogBox()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        EventAgregator.OnPlayerInteractionEnd(gameObject, null); //Notify components that interaction is finished
    }

    
}
