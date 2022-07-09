using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

//Class that manages the displaying of the dialog lines.

[System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S1643:Strings should not be concatenated using '+' in a loop", Justification = "<En attente>")]
[RequireComponent(typeof(TextMeshProUGUI))]
public class DialogTextManager : MonoBehaviour
{
    //Used to verify in the first place if the word we're about to
    //display is too long for the line lenght, in that case we
    //add a line return
    [SerializeField] private TextMeshProUGUI ghostText; 

    private readonly float characterDisplaySpeed = Constants.CHARACTER_DISPLAY_SPEED;
    private TextMeshProUGUI currentText;
    private bool isDisplayingLine;
    private RectTransform parent; //Used to get the width of the Dialog Box
    private string currentLine; //Used to know the lenght of the current line

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
        foreach(string word in GetWords(line)) //Convert line into a list of words
        {
            if (IsWordTooLong(word)) //If the word overflow the width of the dialog box
            {
                currentText.text += "\n"; //Then return to a new line, to avoid undesired auto wrapping
                currentLine = "";
            }
            yield return DisplayElement(word); //Actually display the word
            currentLine += word;
        }
        isDisplayingLine = false;
        currentLine = "";
    }

    //Method to Display a string in the dialog box
    //The string is progressively displayed, one char at a time
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

    //Checks if the word is too long to be displayed on the same line
    private bool IsWordTooLong(string word)
    {
        if (word.Length <= 1)
        {
            return false; //If it's only one char long it's never too long
        }
        else
        {
            //Displaying the text on an invisible Text Box to get the sentence + current word total length
            float totalTextWidth = ghostText.GetTextInfo(currentLine + word).textComponent.textBounds.size.x;

            totalTextWidth += currentText.margin.x + currentText.margin.z; //Sum of the Left and Right Margin

            float textBoxWidth = parent.rect.width; //Width of the dialog box

            if (totalTextWidth > textBoxWidth) //If the total sentence length is greater than the width of the box
            {
                return true; //Then we should get on a new line
            }
            else
            {
                return false;
            }
        }
    }

    //Separate the line into words, following the regex defined in Cosntants
    private string[] GetWords(string line)
    {
        return Regex.Split(line, Constants.SEPARATORS_REGEX);
    }

    public bool IsDisplayingLine => isDisplayingLine;
}
