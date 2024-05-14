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
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
//using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Sprite RS_fail;
    [SerializeField] private Sprite RS_okay;
    [SerializeField] private Sprite RS_golden;
    [SerializeField] private Sprite RS_perfect;
    
    public TextMeshProUGUI totalScore;
    public TextMeshProUGUI missNum;
    public TextMeshProUGUI goodNum;
    public TextMeshProUGUI perfectNum;
    public TextMeshProUGUI highestCombo;
    
    private GameObject gc;
    private Game game;
    private AchievementManager achievements;
    public Animator ResultScreen;
    public GameObject Result;
    public ChangeSkin dancer;

    void Start()
    {
        Cursor.visible = true;
        gc = GameObject.Find("GameController");
        game = gc.GetComponent<Game>();
        achievements = gc.GetComponent<AchievementManager>();
        
        totalScore.text = game.score.ToString() + "%";
        goodNum.text = game.numGood.ToString();
        perfectNum.text = game.numPerfect.ToString();
        missNum.text = game.numMissed.ToString();
        highestCombo.text = game.highestCombo.ToString();
        
        dancer = GameObject.Find("Dancer").GetComponent<ChangeSkin>();
        dancer.ChangeController(game.skin_op);

        if (game.score < 60f)
        {
            Result.GetComponent<Image>().sprite = RS_fail;
            //achievements.UnlockAchievement("fail");
        } 
        else if (game.score < 85f)
        {
            Result.GetComponent<Image>().sprite = RS_okay;
            //achievements.UnlockAchievement("okay");
        } 
        else if (game.score < 100f)
        {
            Result.GetComponent<Image>().sprite = RS_golden;
            //achievements.UnlockAchievement("golden");
        }
        else
        {
            Result.GetComponent<Image>().sprite = RS_perfect;
            //achievements.UnlockAchievement("perfect");
        }

    }

    void Update()
    {
        
    }

    public void onMenuClick()
    {
        game.ResetGame();
        game.ResetOptions();
        StartCoroutine(ReturnToMenu());
    }

    IEnumerator ReturnToMenu()
    {
        ResultScreen.Play("R_fadeout");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MainMenu");
    }

    public void onRestartClick()
    {
        StartCoroutine(TryAgain());
    }

    IEnumerator TryAgain()
    {
        ResultScreen.Play("R_fadeout");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Game");
        game.ResetGame();
        Time.timeScale = 1;
    }
}
