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
    public GameObject golden;
    public GameObject perfect;
    private GameObject gc;
    private Game game;
    private AchievementManager achievements;

    void Start()
    {
        gc = GameObject.Find("GameController");
        game = gc.GetComponent<Game>();
        achievements = gc.GetComponent<AchievementManager>();
        
        totalScore.text = game.score.ToString() + "%";

        if (game.score < 60f)
        {
            fail.SetActive(true);
            golden.SetActive(false);
            okay.SetActive(false);
            perfect.SetActive(false);
            achievements.UnlockAchievement("fail");
        } 
        else if (game.score < 90f)
        {
            fail.SetActive(false);
            golden.SetActive(false);
            okay.SetActive(true);
            perfect.SetActive(false);
            achievements.UnlockAchievement("okay");
        } 
        else if (game.score < 100f)
        {
            fail.SetActive(false);
            golden.SetActive(true);
            okay.SetActive(false);
            perfect.SetActive(false);
            achievements.UnlockAchievement("golden");
        }
        else
        {
            fail.SetActive(false);
            golden.SetActive(false);
            okay.SetActive(false);
            perfect.SetActive(true);
            achievements.UnlockAchievement("perfect");
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
