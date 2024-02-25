/*
Arisa Takenaka Trombley
2375446
trombley@chapman.edu
CPSC-340-02
Type Type Revolution
*/

/* DESCRIPTION
Contains methods that handle the word bank for each game play.
*/
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using System.Linq;

public class WordBank : MonoBehaviour
{
    private Game game;
    private GameObject gc;
    
    private List<string> workingWords = new List<string>();

    private void Awake()
    {
        gc = GameObject.Find("GameController");
        game = gc.GetComponent<Game>();
        workingWords.AddRange(game.gameStuff.themedWords[game.theme_op][game.letter_op]);
        Shuffle(workingWords);
        
    }


    private void Shuffle(List<string> list)
    {
        for (int i = 0; i < list.Count; ++i)
        {
            int random = Random.Range(i, list.Count);
            string temp = list[i];
            list[i] = list[random];
            list[random] = temp;
        }
    }

    public string GetWord()
    {
        string newWord = string.Empty;

        if (workingWords.Count != 0)
        {
            newWord = workingWords.Last();
            workingWords.Remove(newWord);
        }
        return newWord;
    }
}
