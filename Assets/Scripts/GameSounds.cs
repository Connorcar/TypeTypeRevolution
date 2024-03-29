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

    public void playOne()
    {
        hitSound1.pitch = 0.68f;
        hitSound1.Play();
    }

    public void playTwo()
    {
        hitSound1.pitch = 0.76f;
        hitSound1.Play();
    }

    public void playThree()
    {
        hitSound1.pitch = 0.86f;
        hitSound1.Play();
    }

    public void playFour()
    {
        hitSound1.pitch = 1.015f;
        hitSound1.Play();
    }
}
