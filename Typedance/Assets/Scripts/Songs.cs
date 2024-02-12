/*
Arisa Takenaka Trombley
2375446
trombley@chapman.edu
CPSC-340-02
Type Type Revolution
*/

/* DESCRIPTION
Contains methods that handle the buttons on the "Songs" page
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Songs : MonoBehaviour
{
    public GameObject firstSong;
    public GameObject secondSong;
    public GameObject thirdSong;
    // US - unselected S - selected
    [SerializeField] private Sprite US_firstSong;
    [SerializeField] private Sprite S_firstSong;
    [SerializeField] private Sprite US_secondSong;
    [SerializeField] private Sprite S_secondSong;
    [SerializeField] private Sprite US_thirdSong;
    [SerializeField] private Sprite S_thirdSong;
    
    private GameObject gameController;
    private Game gc;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController");
        gc = gameController.GetComponent<Game>();
        gc.ResetGame();
        if (gc.song_op == 0)
        {
            OnFirst();
        }
        else
        {
            switch (gc.song_op)
            {
                case 1:
                    OnSecond();
                    break;
                case 2:
                    OnThird();
                    break;
                default:
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnFirst()
    {
        firstSong.GetComponent<Image>().sprite = S_firstSong;
        secondSong.GetComponent<Image>().sprite = US_secondSong;
        thirdSong.GetComponent<Image>().sprite = US_thirdSong;
        gc.song_op = 0;
    }

    public void OnSecond()
    {
        firstSong.GetComponent<Image>().sprite = US_firstSong;
        secondSong.GetComponent<Image>().sprite = S_secondSong;
        thirdSong.GetComponent<Image>().sprite = US_thirdSong;
        gc.song_op = 1;
    }

    public void OnThird()
    {
        firstSong.GetComponent<Image>().sprite = US_firstSong;
        secondSong.GetComponent<Image>().sprite = US_secondSong;
        thirdSong.GetComponent<Image>().sprite = S_thirdSong;
        gc.song_op = 2;
    }
}
