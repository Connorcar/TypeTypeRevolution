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
using UnityEditor.Animations;

public class Game : MonoBehaviour
{
    public static Game instance;
    public GameStuff gameStuff;
    public double hits = 0;
    public double possibleHits = 0;
    public double score;
    public bool isScoreScene = false;
    public bool isOver;
    public int maximum = 100;
    public int current;
    public Image Mask;
    
    public GameObject GoodHitStatus;
    public GameObject PerfectHitStatus;
    public GameObject MissHitStatus;

    public GameObject HitStatusParent;

    // Game Control Unit
    public int speed_op;
    public int letter_op;
    public int theme_op;
    public int song_op;
    public int skin_op;

    //dancer stuff
    public ChangeSkin dancer;

    // Achievements stuff
    public GameObject achievementParent;
    public string canvasName;
    public Canvas achievementsPopup;
    public Image achievementIcon;
    public TextMeshProUGUI achievementTitle;
    public Transform canvasTransform;
    public Color achievementColor;
    public GameObject achievementPanel;
    public GameObject Combo;
    private Queue<Color> achievementColorQueue = new Queue<Color>();
    private Queue<string> achievementTitleQueue = new Queue<string>();
    private Queue<Image> achievementIconQueue = new Queue<Image>();
    private bool isAchievementPopupOpen = false;
    public AchievementManager achievements;
    
    public RectTransform panelRectTransform;
    public float slideSpeed = 1.0f;
    public float waitTime = 2.0f;
    public Vector2 leftStartPos;
    public Vector2 centerPos;
    public Vector2 rightTargetPos;

    // Combo & Accuracy Stuff
    public int currentCombo = 0;
    public int highestCombo;
    public int numGood;
    public int numPerfect;
    public int numMissed;
    public double currentScore = 0;
    public Color32 lowComboColor; //= new Color32(153, 51, 153, 1);
    public Color32 highComboColor; //= new Color32(255,255,204,1);
    // public double currentAcc = 100;
    private double scorePerGoodNote = 1;
    private double scorePerPerfectNote = 1.25;
    private GameObject MT;
    private GameObject AT;
    private TextMeshProUGUI comboText;
    
    // private TextMeshProUGUI accuracyText;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(achievementsPopup);
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
        getCurrentFill();
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
        Combo = GameObject.Find("Combo");
        MT = GameObject.Find("ComboText");
        // AT = GameObject.Find("AccuracyText");
        comboText = MT.GetComponent<TextMeshProUGUI>();
        // accuracyText = AT.GetComponent<TextMeshProUGUI>();
        GoodHitStatus = GameObject.Find("GoodHitStatus");
        PerfectHitStatus = GameObject.Find("PerfectHitStatus");
        MissHitStatus = GameObject.Find("MissHitStatus");
        HitStatusParent = GameObject.Find("HitStatusParent");
        Mask = GameObject.Find("Mask").GetComponent<Image>();
        GoodHitStatus.SetActive(false);
        PerfectHitStatus.SetActive(false);
        MissHitStatus.SetActive(false);
        Combo.SetActive(true);
        comboText.fontSize = 130;
        comboText.color = lowComboColor;
        currentCombo = 0;
        currentScore = 0;
        // currentAcc = 100;
        dancer = GameObject.Find("Dancer").GetComponent<ChangeSkin>();
        dancer.ChangeController(skin_op);
    }
    
    // Loads score scene and calculates the score
    IEnumerator Scoring()
    {
        
        isScoreScene = true;
        yield return new WaitForSeconds(8);
        
        // score = 100 * hits / possibleHits;
        score = currentScore;
        score = Math.Round(score, 2);
        if (score < 60f)
        {
            achievements.UnlockAchievement("fail");
        } 
        else if (score < 85f)
        {
            achievements.UnlockAchievement("okay");
        } 
        else if (score < 100f)
        {
            achievements.UnlockAchievement("golden");
        }
        else
        {
            achievements.UnlockAchievement("perfect");
        }
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("Score");
        
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
        current = 0;
        highestCombo = 0;
        // currentAcc = 100;
    }

    public void AchievementsPopup(Image currAchievementIcon, string currAchievementTitle)
    {
        if(achievementsPopup.gameObject.GetComponent<CanvasGroup>().alpha == 1){ 
           // Debug.Log("Achievement Popup already open");
            instance.StartCoroutine(WaitForPopup());
        }
        if(currAchievementTitle.Contains("all")){
            achievementColor = new Color(253, 206, 11, 255);
        } 
        achievementsPopup.gameObject.GetComponent<CanvasGroup>().alpha = 1;
        Debug.Log("Achievement Unlocked: " + currAchievementTitle);   
        achievementColorQueue.Enqueue(achievementColor);
        achievementTitleQueue.Enqueue(currAchievementTitle);
        achievementIconQueue.Enqueue(currAchievementIcon);
        if(!isAchievementPopupOpen){
            instance.StartCoroutine(CloseAchievementsPopup());  
        }    
    }

    public IEnumerator CloseAchievementsPopup()
    {
        while(achievementColorQueue.Count > 0)
        {
            isAchievementPopupOpen = true;
            achievementPanel.GetComponent<Image>().color = achievementColorQueue.Dequeue();
            achievementTitle.text = achievementTitleQueue.Dequeue();
            achievementIcon.sprite = achievementIconQueue.Dequeue().sprite;
            while (panelRectTransform.anchoredPosition.x < centerPos.x)
            {
                panelRectTransform.anchoredPosition += new Vector2(slideSpeed * Time.deltaTime, 0);
                yield return null;
            }

            yield return new WaitForSeconds(waitTime);

            while (panelRectTransform.anchoredPosition.x < rightTargetPos.x)
            {
                panelRectTransform.anchoredPosition += new Vector2(slideSpeed * Time.deltaTime, 0);
                yield return null;
            }

            Debug.Log("moving back left");
            panelRectTransform.anchoredPosition = leftStartPos;
        }
        achievementsPopup.gameObject.GetComponent<CanvasGroup>().alpha = 0;
        isAchievementPopupOpen = false;
    }

    public IEnumerator WaitForPopup()
    {
        yield return new WaitForSeconds(3);
    }

    public void NoteHit()
    {
        if (currentCombo > highestCombo)
        {
            highestCombo = currentCombo;
        }

        current = (int)currentScore;
        currentScore = 100 * hits / (possibleHits * scorePerPerfectNote);
        // scoreText.text = "Score: " + Math.Round(currentScore,2) + "%";
        comboText.text = currentCombo.ToString();
        // accuracyText.text = "Accuracy: " + Math.Round(currentAcc,2) + "%";
        /*if (currentCombo == 0)
        {
            comboText.color = lowComboColor;
            Combo.SetActive(true);
        }*/

        if (currentCombo > 2)
        {
            comboText.color = highComboColor;
            comboText.fontSize = 170;
            Combo.SetActive(true);
        }
    }

    public void GoodHit()
    {
        Instantiate(GoodHitStatus, transform.position, Quaternion.identity);
        hits += scorePerGoodNote;
        currentCombo++;
        numGood++;
        // currentAcc -= 100 * 0.25 / possibleHits;
        StartCoroutine(HitStatus(GoodHitStatus));
        HitStatusParent.GetComponent<Animator>().Play("G_goodhit");
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
        HitStatusParent.GetComponent<Animator>().Play("G_perfecthit");
        NoteHit();
    }

    public void NoteMiss()
    {
        //Combo.SetActive(false);
        Instantiate(MissHitStatus, transform.position, Quaternion.identity);
        if (currentCombo > highestCombo)
        {
            highestCombo = currentCombo;
        }
        //Debug.Log("Highest Combo: " + highestCombo);
        currentCombo = 0;
        comboText.color = lowComboColor;
        comboText.fontSize = 130;
        numMissed++;
        // currentAcc -= 100 * 1 / possibleHits;
        StartCoroutine(HitStatus(MissHitStatus));
        HitStatusParent.GetComponent<Animator>().Play("G_misshit");
        comboText.text = currentCombo.ToString();
        // accuracyText.text = "Accuracy: " + Math.Round(currentAcc,2) + "%";
    }

    public void setAchievementColor(Color theme)
    {
        achievementColor = theme;
        achievementPanel.GetComponent<Image>().color = achievementColor;
    }

    public IEnumerator HitStatus(GameObject status)
    {
        status.SetActive(true);
        yield return new WaitForSeconds(1);
        status.SetActive(false);
    }
    
    public void ResetOptions()
    {
        speed_op = 0;
        letter_op = 0;
        theme_op = 0;
        song_op = 0;
        skin_op = 0;
    }

    void getCurrentFill()
    {
        float fillAmount = (float)current / (float)maximum;
        Mask.fillAmount = fillAmount;
    }
    
}