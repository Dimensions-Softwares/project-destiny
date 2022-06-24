using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class DialogTextManager : MonoBehaviour
{
    private float characterDisplaySpeed = Constants.CHARACTER_DISPLAY_SPEED;
    private TextMeshProUGUI currentText;
    private bool isDisplayingLine;

    private void Awake()
    {
        currentText = GetComponent<TextMeshProUGUI>();
        isDisplayingLine = false;
    }

    public IEnumerator DisplayLine(string line)
    {
        isDisplayingLine = true;
        currentText.text = "";
        foreach (char c in line)
        {
            currentText.text += c;
            yield return new WaitForSeconds(characterDisplaySpeed);
        }
        isDisplayingLine = false;
    }

    public bool IsDisplayingLine => isDisplayingLine;
}
