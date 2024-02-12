/*
Arisa Takenaka Trombley
2375446
trombley@chapman.edu
CPSC-340-02
Type Type Revolution
*/

/* DESCRIPTION
Contains methods that handle the scoring scene's appearance and function
*/
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI totalScore;
    public GameObject fail;
    public GameObject okay;
    public GameObject success;
    private GameObject gc;
    private Game game;

    void Start()
    {
        gc = GameObject.Find("GameController");
        game = gc.GetComponent<Game>();
        
        totalScore.text = game.score.ToString() + "%";

        if (game.score < 60f)
        {
            fail.SetActive(true);
            success.SetActive(false);
            okay.SetActive(false);
        } 
        else if (game.score < 90f)
        {
            fail.SetActive(false);
            success.SetActive(false);
            okay.SetActive(true);
        } 
        else if (game.score <= 100f)
        {
            fail.SetActive(false);
            success.SetActive(true);
            okay.SetActive(false);
        }

    }

    void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("Main");
        }
    }
}
