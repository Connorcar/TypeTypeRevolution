/*
Arisa Takenaka Trombley
2375446
trombley@chapman.edu
CPSC-340-02
Type Type Revolution
*/

/* DESCRIPTION
Contains methods that handle the game's typing mechanic
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Words : MonoBehaviour
{
    public TMPro.TextMeshPro wordOutput;
    public GameObject arrow;
    public ArrowSpawner arrowSpawner;
    public AudioSource typeClick;
    
    public string currentWord = string.Empty;
    private string remainingWord = string.Empty;

    void Start()    
    {
        if (arrowSpawner.onScreenArrows.Count != 0)
        {
            arrow = arrowSpawner.onScreenArrows.Peek();
            wordOutput = arrow.GetComponent<Arrow>().wordoutput;
            wordOutput.fontStyle ^= FontStyles.Bold;
            wordOutput.fontStyle ^= FontStyles.Underline;
            currentWord = wordOutput.text;
            SetCurrentWord();
        }
    }

    private void Update()
    {
        CheckInput();
        
    }

    public void SetCurrentWord()
    {
        // print("CURRENT WORD IS: "+ currentWord);
        SetRemainingWord(currentWord);
    }

    private void SetRemainingWord(string newString)
    {
        remainingWord = newString;
        wordOutput.text = remainingWord;
    }
    
    private void CheckInput()
    {
        if (Input.anyKeyDown)
        {
            string keysPressed = Input.inputString;
            if (keysPressed.Length == 1)
            {
                EnterLetter(keysPressed);
            }
        }
    }

    private void EnterLetter(string typedLetter)
    {
        if (isCorrectLetter(typedLetter))
        {
            typeClick.Play();
            RemoveLetter();
            if (IsWordComplete())
            {
                arrow.GetComponent<Arrow>().isFullyTyped = true;
            }
        }
    }

    private bool isCorrectLetter(string letter)
    {
        return remainingWord.IndexOf(letter) == 0;
    }

    private void RemoveLetter()
    {
        string newString = remainingWord.Remove(0, 1);
        SetRemainingWord(newString);
    }

    private bool IsWordComplete()
    {
        return remainingWord.Length == 0;
    }

    public void ResetCurrentWord()
    {
        if (arrowSpawner.onScreenArrows.Count != 0)
        {
            arrow = arrowSpawner.onScreenArrows.Peek();
            StartCoroutine("WaitForWord");
        }
    }

    IEnumerator WaitForWord()
    {
        yield return new WaitUntil(() => !(arrow.GetComponent<Arrow>().wordoutput.text).Equals(""));
        // Debug.Log("WAITED FOR WORD: '" + arrow.GetComponent<Arrow>().wordoutput.text + "'");
        wordOutput = arrow.GetComponent<Arrow>().wordoutput;
        wordOutput.fontStyle ^= FontStyles.Bold;
        wordOutput.fontStyle ^= FontStyles.Underline;
        currentWord = wordOutput.text;
        SetCurrentWord();
    }
}
