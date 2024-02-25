/*
Arisa Takenaka Trombley
2375446
trombley@chapman.edu
CPSC-340-02
Type Type Revolution
*/

/* DESCRIPTION
Contains methods that help to demo the game play for the tutorial page. 
Unused/left for future production
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class wordDemo : MonoBehaviour
{
    public Canvas Tutorial1;
    public GameObject demo;
    
    private TextMeshPro demoWord;
    private Canvas Tutorial1Canvas;
    private string word;
    private bool isTyping = false;

    // Start is called before the first frame update
    void Start()
    {
        Tutorial1Canvas = Tutorial1.GetComponent<Canvas>();
    }

    private IEnumerator TypeWordDemo()
    {
        string original = demoWord.text;

        word = demoWord.text;

        while (word.Length != 0)
        {
            yield return new WaitForSeconds(0.3f);
            word.Remove(0, 1);
            demoWord.text = word;
        }

        demoWord.text = original;

        if (Tutorial1Canvas.enabled)
        {
            StartCoroutine("TypeWordDemo");
        }
    }
    
    void Update()
    {
        if (Tutorial1Canvas.enabled)
        {
            if (!isTyping)
            {
                isTyping = true;
                demoWord = demo.GetComponent<TextMeshPro>();
                StartCoroutine("TypeWordDemo");
            }
        }
    }
}
