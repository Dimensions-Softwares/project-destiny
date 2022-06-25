using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class DialogTextManager : MonoBehaviour
{
    private float characterDisplaySpeed = Constants.CHARACTER_DISPLAY_SPEED;
    private TextMeshProUGUI currentText;
    private bool isDisplayingLine;
    private RectTransform parent;
    private float charWidth = Constants.CHARACTER_WIDTH;
    private string currentLine;

    private void Awake()
    {
        currentText = GetComponent<TextMeshProUGUI>();
        isDisplayingLine = false;
        parent = GetComponentInParent<RectTransform>();
        currentLine = "";
    }

    public IEnumerator DisplayLine(string line)
    {
        isDisplayingLine = true;
        currentText.text = "";
        foreach(string word in GetWords(line))
        {
            if (IsWordTooLong(word))
            {
                currentText.text += "\n";
                currentLine = "";
            }
            yield return DisplayElement(word);
            currentLine += word;
        }
        isDisplayingLine = false;
        currentLine = "";
    }

    private IEnumerator DisplayElement(string element)
    {
        for (int i = 0; i < element.Length; i++)
        {
            currentText.text += element[i];
            if (i < element.Length - 1)
            {
                yield return new WaitForSeconds(characterDisplaySpeed);
            }
        }
    }
    private bool IsWordTooLong(string word)
    {
        if(word.Length <= 1)
        {
            return false;
        }
        else
        {
            float textBoxWidth = parent.rect.width;
            if (charWidth * (word.Length + currentLine.Length) > textBoxWidth)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    private string[] GetWords(string line)
    {
        return Regex.Split(line, Constants.SEPARATORS_REGEX);
    }

    public bool IsDisplayingLine => isDisplayingLine;
}
