/*
Arisa Takenaka Trombley
2375446
trombley@chapman.edu
CPSC-340-02
Type Type Revolution
*/

/* DESCRIPTION
Contains methods that configure the game's sky based on chosen theme
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SkyChange : MonoBehaviour
{
    public VideoClip defaultSky;
    public VideoClip oceanSky;
    public VideoClip winterSky;
    public VideoClip farmSky;
    public VideoClip evilSky;
    public VideoPlayer sky;

    private List<VideoClip> skyList = new List<VideoClip>();

    private GameObject gameController;
    private Game gc;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController");
        gc = gameController.GetComponent<Game>();
        skyList.Add(defaultSky);
        skyList.Add(farmSky);
        skyList.Add(oceanSky);
        skyList.Add(winterSky);
        skyList.Add(evilSky);
        
        sky.clip = skyList[gc.theme_op];
        if (gc.theme_op == 1)
        {
            sky.playbackSpeed = 0.5f;
        } 
    }
}
