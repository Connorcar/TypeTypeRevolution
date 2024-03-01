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

public class Game : MonoBehaviour
{
    public static Game instance;
    public GameStuff gameStuff;
    public double hits = 0;
    public double possibleHits = 0;
    public double score;
    public bool isScoreScene = false;
    public bool isOver;
    
    // Game Control Unit
    public int speed_op;
    public int letter_op;
    public int theme_op;
    public int song_op;

    //Achievements stuff
    public GameObject achievementParent;
    public string canvasName;
    public Canvas achievementsPopup;
    public Image achievementIcon;
    public TextMeshProUGUI achievementTitle;

    private void Awake()
    {
        if (instance != null)
    {
        Destroy(gameObject);
        return;
    }

    instance = this;

    // Find the canvas by name
    Transform canvasTransform = instance.transform.Find(canvasName);

    if (canvasTransform != null)
    {
        // Get the Canvas component from the found canvas Transform
        achievementsPopup = canvasTransform.GetComponent<Canvas>();
        achievementIcon = canvasTransform.GetComponentInChildren<Image>();
        achievementTitle = canvasTransform.GetComponentInChildren<TextMeshProUGUI>();
    }
    else
    {
        Debug.LogError("Canvas with the name: " + canvasName + " not found.");
    }

    DontDestroyOnLoad(gameObject);
    DontDestroyOnLoad(achievementsPopup);
    DontDestroyOnLoad(achievementIcon);
    DontDestroyOnLoad(achievementTitle);

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
    
    // Loads score scene and calculates the score
    IEnumerator Scoring()
    {
        isScoreScene = true;
        yield return new WaitForSeconds(8);
        SceneManager.LoadScene("Score");
        score = 100 * hits / possibleHits;
        score = Math.Round(score, 2);
        
    }

    // Resets the game 
    public void ResetGame()
    {
        isScoreScene = false;
        isOver = false;
        hits = 0;
        score = 0;
    }

    public void AchievementsPopup(Image currAchievementIcon, TextMeshProUGUI currAchievementTitle)
    {
        achievementsPopup.gameObject.GetComponent<CanvasGroup>().alpha = 1;
        Debug.Log("Achievement Unlocked: " + currAchievementTitle.text);    
        achievementIcon.color = currAchievementIcon.color;
        achievementTitle.text = currAchievementTitle.text;
        instance.StartCoroutine(CloseAchievementsPopup());
    }

    public IEnumerator CloseAchievementsPopup()
    {
        yield return new WaitForSeconds(3);
        achievementsPopup.gameObject.GetComponent<CanvasGroup>().alpha = 0;
    }
    
   
}
