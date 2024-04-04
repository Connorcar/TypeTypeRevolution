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
    public Animator ResultScreen;
    public GameObject Result;

    void Start()
    {

        gc = GameObject.Find("GameController");
        game = gc.GetComponent<Game>();
        achievements = gc.GetComponent<AchievementManager>();
        
        totalScore.text = game.score.ToString() + "%";

        if (game.score < 60f)
        {
            /* fail.SetActive(true);
             golden.SetActive(false);
             okay.SetActive(false);
             perfect.SetActive(false);*/
            Result.GetComponent<Image>().sprite.name = "R_fail";
            achievements.UnlockAchievement("fail");
        } 
        else if (game.score < 90f)
        {
            Result.GetComponent<Image>().sprite.name = "R_okay";
            achievements.UnlockAchievement("okay");
        } 
        else if (game.score < 100f)
        {
            Result.GetComponent<Image>().sprite.name = "R_golden";
            achievements.UnlockAchievement("golden");
        }
        else
        {
            Result.GetComponent<Image>().sprite.name = "R_perfect";
            achievements.UnlockAchievement("perfect");
        }

    }

    void Update()
    {
        if (Input.anyKey)
        {
            StartCoroutine(ReturnToMenu());
        }
    }

    IEnumerator ReturnToMenu()
    {
        ResultScreen.Play("R_fadeout");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MainMenu");
    }
}
