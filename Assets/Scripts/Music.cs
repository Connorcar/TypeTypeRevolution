/*
Arisa Takenaka Trombley
2375446
trombley@chapman.edu
CPSC-340-02
Type Type Revolution
*/

/* DESCRIPTION
Contains method that handles the game music
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource Bay;
    public AudioSource Resolve;
    
    private Game game;
    private GameObject gc;
    void Start()
    {
        gc = GameObject.Find("GameController");
        game = gc.GetComponent<Game>();
        switch (game.song_op)
        {
            case 0:
                Bay.Play();
                break;
            case 1:
                Resolve.Play();
                break;
            default:
                break;
        }
    }
}
