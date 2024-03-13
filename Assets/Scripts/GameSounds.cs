/*
Arisa Takenaka Trombley
2375446
trombley@chapman.edu
CPSC-340-02
Type Type Revolution
*/

/* DESCRIPTION
Contains methods that handle game sound effects 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSounds : MonoBehaviour
{
    public AudioSource hitSound1;
    public AudioSource hitSound2;
    public AudioSource hitSound3;
    public AudioSource hitSound4;

    public void playOne()
    {
        hitSound1.Play();
    }

    public void playTwo()
    {
        hitSound1.Play();
    }

    public void playThree()
    {
        hitSound1.Play();
    }

    public void playFour()
    {
        hitSound1.Play();
    }
}
