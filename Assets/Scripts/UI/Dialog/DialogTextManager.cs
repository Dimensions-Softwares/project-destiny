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

    private void Awake()
    {
        currentText = GetComponent<TextMeshProUGUI>();
        isDisplayingLine = false;
    }

    public IEnumerator DisplayLine(string line)
    {
        isDisplayingLine = true;
        currentText.text = "";
        foreach(string element in GetWords(line))
        {
            if (IsWordTooLong(element))
            {
                currentText.text += "\n";
            }
            yield return DisplayElement(element);
        }
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
            int lastChar = currentText.text.Length - 1;
            float linePos = currentText.textInfo.characterInfo[lastChar].xAdvance;
            float charWidth = linePos / currentText.text.Length;
            if(charWidth * word.Length + linePos > 500)
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
