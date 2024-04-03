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
    private GameObject gameController;
    private Game gc;

    public AudioSource hitSound1;

    public float[] bayHitPitchValues = { 0.68f, 0.76f, 0.86f, 1.015f };
    public float[] resolveHitPitchValues = { 0.75f, 0.84f, 0.94f, 1.13f };

    private float[] currHitPitchValues = { };

    private void Start()
    {
        gameController = GameObject.Find("GameController");
        gc = gameController.GetComponent<Game>();

        switch (gc.song_op)
        {
            case 0: // bay
                currHitPitchValues = bayHitPitchValues;
                break;
            case 1: // resolve
                currHitPitchValues = resolveHitPitchValues;
                break;
        }
    }

    public void playOne()
    {
        hitSound1.pitch = currHitPitchValues[0];
        hitSound1.Play();
    }

    public void playTwo()
    {
        hitSound1.pitch = currHitPitchValues[1];
        hitSound1.Play();
    }

    public void playThree()
    {
        hitSound1.pitch = currHitPitchValues[2];
        hitSound1.Play();
    }

    public void playFour()
    {
        hitSound1.pitch = currHitPitchValues[3];
        hitSound1.Play();
    }
}
