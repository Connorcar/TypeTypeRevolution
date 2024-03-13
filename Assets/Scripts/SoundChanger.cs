/*
Connor Caruthers
2365827
ccaruthers@chapman.edu
CPSC-340-02
Type Type Revolution
*/

/* DESCRIPTION
Contains methods that configure the game's sound effects based on chosen theme
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundChanger : MonoBehaviour
{
    public AudioClip default_type;
    public AudioClip default_hit;

    public AudioClip winter_type;
    public AudioClip winter_hit;

    public AudioClip ocean_type;
    public AudioClip ocean_hit;

    public AudioClip farm_type;
    public AudioClip farm_hit;

    public AudioClip evil_type;
    public AudioClip evil_hit;

    private GameObject gameController;
    private Game gc;

    private Words typer;
    private GameSounds hitter;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController");
        gc = gameController.GetComponent<Game>();

        typer = GameObject.Find("Typer").GetComponent<Words>();
        hitter = GameObject.Find("SoundEffects").GetComponent<GameSounds>();

        switch (gc.theme_op)
        {
            case 0: // default theme
                typer.GetComponent<AudioSource>().clip = default_type;
                hitter.hitSound1.clip = default_hit;
                break;
            case 1: // ocean theme
                typer.GetComponent<AudioSource>().clip = ocean_type;
                hitter.hitSound1.clip = ocean_hit;
                break; 
            case 2: // winter theme
                typer.GetComponent<AudioSource>().clip = winter_type;
                hitter.hitSound1.clip = winter_hit;
                break;
            case 3: // farm theme
                typer.GetComponent<AudioSource>().clip = farm_type;
                hitter.hitSound1.clip = farm_hit;
                break;
            case 4: // evil theme
                typer.GetComponent<AudioSource>().clip = evil_type;
                hitter.hitSound1.clip = evil_hit;
                break; 
        }
        /*
        skyList.Add(defaultSky);
        skyList.Add(oceanSky);
        skyList.Add(winterSky);
        skyList.Add(farmSky);
        skyList.Add(evilSky);

        RenderSettings.skybox = skyList[gc.theme_op];
        */
    }
}
