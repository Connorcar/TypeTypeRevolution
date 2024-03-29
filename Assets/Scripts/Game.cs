/*
Arisa Takenaka Trombley
2375446
trombley@chapman.edu
CPSC-340-02
Type Type Revolution
*/

/* DESCRIPTION
Contains attributes that act as game settings and methods that handle the game scoring and resetting
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Transactions;
using Unity.VisualScripting;

public class Game : MonoBehaviour
{
    public static Game instance;
    public GameStuff gameStuff;
    public double hits = 0;
    public double possibleHits = 0;
    public double score;
    public bool isScoreScene = false;
    public bool isOver;
    
    public GameObject GoodHitStatus;
    public GameObject PerfectHitStatus;

    // Game Control Unit
    public int speed_op;
    public int letter_op;
    public int theme_op;
    public int song_op;

    // Achievements stuff
    public GameObject achievementParent;
    public string canvasName;
    public Canvas achievementsPopup;
    public Image achievementIcon;
    public TextMeshProUGUI achievementTitle;
    public Transform canvasTransform;
    public Color achievementColor;
    public GameObject achievementPanel;
    // public Color defaultColor;
    // public Color farmColor;
    // public Color oceanColor;
    // public Color winterColor;
    // public Color evilColor;

    // Combo & Accuracy Stuff
    public int currentCombo = 0;
    public int highestCombo;
    public int numGood;
    public int numPerfect;
    public int numMissed;
    public double currentScore = 0;
    public double currentAcc = 100;
    private double scorePerGoodNote = 1;
    private double scorePerPerfectNote = 1.25;
    private GameObject ST;
    private GameObject MT;
    private GameObject AT;
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI comboText;
    private TextMeshProUGUI accuracyText;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        // Find the canvas by name
        //Transform canvasTransform = instance.transform.Find(canvasName);

        // if (canvasTransform != null)
        // {
            // Get the Canvas component from the found canvas Transform
            // achievementsPopup = canvasTransform.GetComponent<Canvas>();
            // achievementIcon = canvasTransform.GetComponentInChildren<Image>();
            // achievementTitle = canvasTransform.GetComponentInChildren<TextMeshProUGUI>();

            DontDestroyOnLoad(achievementsPopup);
            //DontDestroyOnLoad(achievementIcon);
            //DontDestroyOnLoad(achievementTitle);
        // }
        // else
        // {
        //     Debug.LogError("Canvas with the name: " + canvasName + " not found.");
        // }

        DontDestroyOnLoad(gameObject);
  

        if (achievementsPopup != null)
        {
            achievementsPopup.gameObject.GetComponent<CanvasGroup>().alpha = 0;
            achievementsPopup.gameObject.GetComponent<CanvasGroup>().interactable = false;
            achievementsPopup.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        
        if (isOver && !isScoreScene)
        {
            StartCoroutine(Scoring());
        }
        
    }

    public void GameSceneSetup()
    {
        Debug.Log("Game Scene Setup");
        ST = GameObject.Find("ScoreText");
        MT = GameObject.Find("ComboText");
        AT = GameObject.Find("AccuracyText");
        scoreText = ST.GetComponent<TextMeshProUGUI>();
        comboText = MT.GetComponent<TextMeshProUGUI>();
        accuracyText = AT.GetComponent<TextMeshProUGUI>();
        GoodHitStatus = GameObject.Find("GoodHitStatus");
        PerfectHitStatus = GameObject.Find("PerfectHitStatus");
        GoodHitStatus.SetActive(false);
        PerfectHitStatus.SetActive(false);
        currentCombo = 0;
        currentScore = 0;
        currentAcc = 100;
    }
    
    // Loads score scene and calculates the score
    IEnumerator Scoring()
    {
        isScoreScene = true;
        yield return new WaitForSeconds(8);
        SceneManager.LoadScene("Score");
        // score = 100 * hits / possibleHits;
        score = currentScore;
        score = Math.Round(score, 2);
        
    }

    // Resets the game 
    public void ResetGame()
    {
        isScoreScene = false;
        isOver = false;
        hits = 0;
        score = 0;
        numGood = 0;
        numPerfect = 0;
        numMissed = 0;
        currentCombo = 0;
        currentScore = 0;
        currentAcc = 100;
    }

    public void AchievementsPopup(Image currAchievementIcon, string currAchievementTitle)
    {
        achievementsPopup.gameObject.GetComponent<CanvasGroup>().alpha = 1;
        Debug.Log("Achievement Unlocked: " + currAchievementTitle);    
        achievementIcon = currAchievementIcon;
        achievementTitle.text = currAchievementTitle;
        achievementPanel.GetComponent<Image>().color = achievementColor;
        instance.StartCoroutine(CloseAchievementsPopup());
    }

    public IEnumerator CloseAchievementsPopup()
    {
        yield return new WaitForSeconds(3);
        achievementsPopup.gameObject.GetComponent<CanvasGroup>().alpha = 0;
    }

    public void NoteHit()
    {
        currentScore = 100 * hits / (possibleHits * scorePerPerfectNote);
        scoreText.text = "Score: " + Math.Round(currentScore,2) + "%";
        comboText.text = "Combo: " + currentCombo;
        accuracyText.text = "Accuracy: " + Math.Round(currentAcc,2) + "%";

    }

    public void GoodHit()
    {
        Instantiate(GoodHitStatus, transform.position, Quaternion.identity);
        hits += scorePerGoodNote;
        currentCombo++;
        numGood++;
        currentAcc -= 100 * 0.25 / possibleHits;
        StartCoroutine(HitStatus(GoodHitStatus));
        NoteHit();
    }
    
    // TODO: Coroutines for the hit animations OK PERFECT MISS

    public void PerfectHit()
    {
        Instantiate(PerfectHitStatus, transform.position, Quaternion.identity);
        // currentScore += scorePerPerfectNote * currentMultiplier;
        hits += scorePerPerfectNote;
        currentCombo++;
        numPerfect++;
        StartCoroutine(HitStatus(PerfectHitStatus));
        NoteHit();
    }

    public void NoteMiss()
    {
        highestCombo = currentCombo;
        Debug.Log("Highest Combo: " + highestCombo);
        currentCombo = 0;
        numMissed++;
        currentAcc -= 100 * 1 / possibleHits;
        comboText.text = "Combo: " + currentCombo;
    }

    public void setAchievementColor(Color theme)
    {
        // themeText = themeText.ToLower();
        // if(themeText == "default"){
        //     achievementColor = defaultColor;
        // }else if(themeText == "ocean"){
        //     achievementColor = oceanColor;
        // }else if(themeText == "farm"){
        //     achievementColor = farmColor;
        // }else if(themeText == "winter"){
        //     achievementColor = winterColor;
        // }else if(themeText == "evil"){
        //     achievementColor = evilColor;
        // }
        // Debug.Log("Achievement Color: " + themeText);
        achievementColor = theme;
        achievementPanel.GetComponent<Image>().color = achievementColor;
    }

    public IEnumerator HitStatus(GameObject status)
    {
        status.SetActive(true);
        yield return new WaitForSeconds(1);
        status.SetActive(false);
    }
    
    
    
}
