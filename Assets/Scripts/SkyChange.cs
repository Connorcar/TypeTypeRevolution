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
    public VideoPlayer videoPlayer;

    public VideoClip defaultBG;
    public VideoClip oceanBG;
    public VideoClip winterBG;
    public VideoClip farmBG;
    public VideoClip evilBG;

    /*
    public Material defaultSky;
    public Material oceanSky;
    public Material winterSky;
    public Material farmSky;
    public Material evilSky;
    */

    private List<VideoClip> skyList = new List<VideoClip>();

    private GameObject gameController;
    private Game gc;
    private VideoClip clip;


    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController");
        gc = gameController.GetComponent<Game>();
        skyList.Add(defaultBG);
        skyList.Add(oceanBG);
        skyList.Add(winterBG);
        skyList.Add(farmBG);
        skyList.Add(evilBG);

        clip = skyList[gc.theme_op];

        videoPlayer.GetComponent<VideoPlayer>();
        videoPlayer.clip = clip;
    }
}

