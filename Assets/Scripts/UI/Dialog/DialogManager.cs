using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    private DialogObject dialog;
    [SerializeField] private DialogTextManager textManager;
    private List<string> dialogLines;
    void Start()
    {
        dialogLines = new List<string>(dialog.linesList);
        DisplayNextLine();
    }

    // Update is called once per frame
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
                DestroyDialogBox();
            }
        }
    }

    private void DisplayNextLine()
    {
        StartCoroutine(textManager.DisplayLine(dialogLines[0]));
        dialogLines.RemoveAt(0);
    }

    public void SetDialogObject(DialogObject dialogObject)
    {
        dialog = dialogObject;
    }

    private void DestroyDialogBox()
    {

        Destroy(gameObject);
    }


}
