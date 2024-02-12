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

public class SkyChange : MonoBehaviour
{
    public Material defaultSky;
    public Material oceanSky;
    public Material winterSky;
    public Material farmSky;
    public Material evilSky;

    private List<Material> skyList = new List<Material>();

    private GameObject gameController;
    private Game gc;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController");
        gc = gameController.GetComponent<Game>();
        skyList.Add(defaultSky);
        skyList.Add(oceanSky);
        skyList.Add(winterSky);
        skyList.Add(farmSky);
        skyList.Add(evilSky);

        RenderSettings.skybox = skyList[gc.theme_op];
    }
}
