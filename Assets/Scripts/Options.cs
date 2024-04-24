/*
Arisa Takenaka Trombley
2375446
trombley@chapman.edu
CPSC-340-02
Type Type Revolution
*/

/* DESCRIPTION
Contains methods that handle the buttons in the "Options" Page
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Properties;
using UnityEditor;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class Options : MonoBehaviour
{
    
    // Difficulty Presets
    // public GameObject PresetPanel;
    public TextMeshProUGUI presetText;
    private Image presetBacking;
    
    // Speed
    // public GameObject ModePanel;
    public TextMeshProUGUI modeText;
    private Image modeBacking;
    
    // Word Length
    // public GameObject WLPanel;
    public TextMeshProUGUI WLText;
    private Image WLBacking;

    // Theme
    // public GameObject StylePanel;
    public TextMeshProUGUI themeText;
    private Image themeBacking;
    
    // Song
    // public GameObject SongPanel;
    public TextMeshProUGUI songText;
    private Image songBacking;
    public bool isPlaying = false;
    public TextMeshProUGUI playText;
    public AudioSource bay;
    public AudioSource resolve;
    public AudioSource mainMenuMusic;
    
    public GameObject CustomPanel;
    private GameObject gameController;
    private Game gc;
    private GameStuff gs;
    private AchievementManager am;

    public Image leftPresetArrow;
    public Image rightPresetArrow;
    public Image leftSpeedArrow;
    public Image rightSpeedArrow;
    public Image leftLetterArrow;
    public Image rightLetterArrow;
    public Image leftThemeArrow;
    public Image rightThemeArrow;
    public Image leftSongArrow;
    public Image rightSongArrow;

    
    private List<string> presetArr = new List<string>()
    {
        "Easy", "Norm", "Hard", "Demon"
    };
    
    private List<string> modeArr = new List<string>()
    {
        "Slow", "Norm", "Fast", "Rapid"
    };
    
    private List<string> WLArr = new List<string>()
    {
        "3-4", "4-5", "5-6", "6+"
    };
    
    private List<string> themeArr = new List<string>()
    {
        "Default", "Farm", "Ocean", "Winter", "Evil"
    };

    private List<string> songArr = new List<string>()
    {
        "Bay", "Resolve"
    }; 

    private void Awake()
    {
        gameController = GameObject.Find("GameController");
        gc = gameController.GetComponent<Game>();
        gs = gameController.GetComponent<GameStuff>();
        am = gameController.GetComponent<AchievementManager>();
        InitialSetup();
    }

    private void InitialSetup()
    {
        
        if (gc.letter_op == 0 && gc.song_op == 0 &&
            gc.speed_op == 0 && gc.theme_op == 0 && gc.song_op == 0)
        {
            CustomPanel.SetActive(false);
            presetText.GetComponent<TextMeshProUGUI>().text = presetArr[0];
            modeText.GetComponent<TextMeshProUGUI>().text = modeArr[0];
            WLText.GetComponent<TextMeshProUGUI>().text = WLArr[0];
            themeText.GetComponent<TextMeshProUGUI>().text = themeArr[0];
            songText.GetComponent<TextMeshProUGUI>().text = songArr[0];
            
            gc.speed_op = 0;
            gc.letter_op = 0;
            gc.theme_op = 0;
            gc.song_op = 0;
            gc.skin_op = 0;
        }
        else
        {
            setPreset();
            setMode();
            setWL();
            setTheme();
            setSong();
        }

        leftPresetArrow.enabled = false;
        leftSpeedArrow.enabled = false;
        leftLetterArrow.enabled = false;
        leftThemeArrow.enabled = false;
        leftSongArrow.enabled = false;
        
    }

    private void setPreset()
    {
        if (gc.speed_op == gc.letter_op)
        {
            CustomPanel.SetActive(false);
            changePresetColor(gc.speed_op);
            presetText.GetComponent<TextMeshProUGUI>().text = presetArr[gc.speed_op];
        }
        else
        {
            CustomPanel.SetActive(true);
            presetBacking.color = Color.green;
            presetText.GetComponent<TextMeshProUGUI>().text = presetArr[0];
        }
    }

    private void setSong()
    {
        songText.GetComponent<TextMeshProUGUI>().text = songArr[gc.song_op];
    }

    private void setMode()
    {
        changeModeColor(gc.speed_op);
        modeText.GetComponent<TextMeshProUGUI>().text = modeArr[gc.speed_op];
    }

    private void setWL()
    {
        changeWLColor(gc.letter_op);
        WLText.GetComponent<TextMeshProUGUI>().text = WLArr[gc.letter_op];
    }

    private void setTheme()
    {
        gc.theme_op = 0;
        gc.setAchievementColor(gs.themeColors[gc.theme_op]);
        themeText.GetComponent<TextMeshProUGUI>().text = themeArr[gc.theme_op];
        
    }

    public void onPresetNext()
    {
        leftPresetArrow.enabled = true;
        leftSpeedArrow.enabled = true;
        leftLetterArrow.enabled = true;

        CustomPanel.SetActive(false);
        int currIndex = presetArr.IndexOf(presetText.GetComponent<TextMeshProUGUI>().text);
        if (currIndex < 3)
        {  
            presetText.GetComponent<TextMeshProUGUI>().text = presetArr[++currIndex];
            if (currIndex == 3)
            {
                rightPresetArrow.enabled = false;
                rightSpeedArrow.enabled = false;
                rightLetterArrow.enabled = false;
            }
        }
        else
        {
            currIndex = 3;
            presetText.GetComponent<TextMeshProUGUI>().text = presetArr[3];
        }

        print(currIndex);

        modeText.GetComponent<TextMeshProUGUI>().text = modeArr[currIndex];
        WLText.GetComponent<TextMeshProUGUI>().text = WLArr[currIndex];

        changePresetColor(currIndex);

        am.setDifficulty(presetText.GetComponent<TextMeshProUGUI>().text);
    }
    

    public void onPresetPrev()
    {
        rightPresetArrow.enabled = true;
        rightSpeedArrow.enabled = true;
        rightLetterArrow.enabled = true;

        CustomPanel.SetActive(false);
        int currIndex = presetArr.IndexOf(presetText.GetComponent<TextMeshProUGUI>().text);
        if (currIndex > 0)
        {
            presetText.GetComponent<TextMeshProUGUI>().text = presetArr[--currIndex];
            if (currIndex == 0)
            {
                leftPresetArrow.enabled = false;
                leftSpeedArrow.enabled = false;
                leftLetterArrow.enabled = false;
            }
        }
        else
        {
            currIndex = 0;
            presetText.GetComponent<TextMeshProUGUI>().text = presetArr[0];
        }
        
        modeText.GetComponent<TextMeshProUGUI>().text = modeArr[currIndex];
        WLText.GetComponent<TextMeshProUGUI>().text = WLArr[currIndex];
        
        changePresetColor(currIndex);

        am.setDifficulty(presetText.GetComponent<TextMeshProUGUI>().text);
    }
    
    private void changePresetColor(int currIndex)
    {
        gc.speed_op = currIndex;
        gc.letter_op = currIndex;
    }


    public void onModeNext()
    {
        leftSpeedArrow.enabled = true;
        
        int currIndex = modeArr.IndexOf(modeText.GetComponent<TextMeshProUGUI>().text);
        if (currIndex < 3)
        {
            modeText.GetComponent<TextMeshProUGUI>().text = modeArr[++currIndex];
            if (currIndex == 3)
            {
                rightSpeedArrow.enabled = false;
            }
        }
        else
        {
            currIndex = 3;
            modeText.GetComponent<TextMeshProUGUI>().text = modeArr[3];
        }
        
        changeModeColor(currIndex);
    }

    public void onModePrev()
    {
        rightSpeedArrow.enabled = true;
        
        int currIndex = modeArr.IndexOf(modeText.GetComponent<TextMeshProUGUI>().text);
        if (currIndex > 0)
        {
            modeText.GetComponent<TextMeshProUGUI>().text = modeArr[--currIndex];
            if (currIndex == 0)
            {
                leftSpeedArrow.enabled = false;
            }
        }
        else
        {
            currIndex = 0;
            modeText.GetComponent<TextMeshProUGUI>().text = modeArr[0];
        }
        
        changeModeColor(currIndex);
    }

    private void changeModeColor(int currIndex)
    {
        gc.speed_op = currIndex;
        
        if (gc.speed_op != gc.letter_op)
        {
            CustomPanel.SetActive(true);
        }
    }

    public void onWLNext()
    {
        leftLetterArrow.enabled = true;
        
        int currIndex = WLArr.IndexOf(WLText.GetComponent<TextMeshProUGUI>().text);
        if (currIndex < 3)
        {
            WLText.GetComponent<TextMeshProUGUI>().text = WLArr[++currIndex];
            if (currIndex == 3)
            {
                rightLetterArrow.enabled = false;
            }
        }
        else
        {
            currIndex = 3;
            WLText.GetComponent<TextMeshProUGUI>().text = WLArr[3];
        }
        
        changeWLColor(currIndex);
    }

    public void onWLPrev()
    {
        rightLetterArrow.enabled = true;

        int currIndex = WLArr.IndexOf(WLText.GetComponent<TextMeshProUGUI>().text);
        if (currIndex > 0)
        {
            WLText.GetComponent<TextMeshProUGUI>().text = WLArr[--currIndex];
            if (currIndex == 0)
            {
                leftLetterArrow.enabled = false;
            }
        }
        else
        {
            currIndex = 0;
            WLText.GetComponent<TextMeshProUGUI>().text = WLArr[0];
        }

        changeWLColor(currIndex);
    }

    private void changeWLColor(int currIndex)
    {
        gc.letter_op = currIndex;
        
        if (gc.speed_op != gc.letter_op)
        {
            CustomPanel.SetActive(true);
        }
    }
    
    public void onThemeNext()
    {
        leftThemeArrow.enabled = true;

        int currIndex = themeArr.IndexOf(themeText.GetComponent<TextMeshProUGUI>().text);
        if (currIndex < 4)
        {
            themeText.GetComponent<TextMeshProUGUI>().text = themeArr[++currIndex];
            if (currIndex == 4)
            {
                rightThemeArrow.enabled = false;
            }
        }
        else
        {
            currIndex = 4;
            themeText.GetComponent<TextMeshProUGUI>().text = themeArr[4];
        }

        Debug.Log("current theme is " + themeText.GetComponent<TextMeshProUGUI>().text);
        am.setTheme(themeText.GetComponent<TextMeshProUGUI>().text);
        
        gc.theme_op = currIndex;
        gc.setAchievementColor(gs.themeColors[gc.theme_op]);
    }

    public void onThemePrev()
    {
        rightThemeArrow.enabled = true;

        int currIndex = themeArr.IndexOf(themeText.GetComponent<TextMeshProUGUI>().text);
        if (currIndex > 0)
        {
            themeText.GetComponent<TextMeshProUGUI>().text = themeArr[--currIndex];
            if (currIndex == 0)
            {
                leftThemeArrow.enabled = false;
            }
        }
        else
        {
            currIndex = 0;
            themeText.GetComponent<TextMeshProUGUI>().text = themeArr[0];
        }

        Debug.Log("current theme is " + themeText.GetComponent<TextMeshProUGUI>().text);
        am.setTheme(themeText.GetComponent<TextMeshProUGUI>().text);

        gc.theme_op = currIndex;
        gc.setAchievementColor(gs.themeColors[gc.theme_op]);
    }

    public void onSongNext()
    {
        leftSongArrow.enabled = true;

        int currIndex = songArr.IndexOf(songText.GetComponent<TextMeshProUGUI>().text);
        if (currIndex < 1)
        {
            themeText.GetComponent<TextMeshProUGUI>().text = themeArr[++currIndex];
            if (currIndex == 1)
            {
                rightSongArrow.enabled = false;
            }
        }
        else
        {
            currIndex = 1;
            themeText.GetComponent<TextMeshProUGUI>().text = themeArr[1];
        }
        if(isPlaying){
            Debug.Log("stoping preview");
            onSongPreviewClick();
        }        
        gc.song_op = currIndex;

        am.setSong(gc.song_op);
    }

    public void onSongPrev()
    {
        rightSongArrow.enabled = true;
        int currIndex = songArr.IndexOf(songText.GetComponent<TextMeshProUGUI>().text);
        if (currIndex > 0)
        {
            songText.GetComponent<TextMeshProUGUI>().text = songArr[--currIndex];
            if (currIndex == 0)
            {
                leftSongArrow.enabled = false;
            }
        }
        else
        {
            currIndex = 0;
            songText.GetComponent<TextMeshProUGUI>().text = songArr[0];
        }
        if(isPlaying){
            Debug.Log("stoping preview");
            onSongPreviewClick();
        }
        gc.song_op = currIndex;

        am.setSong(gc.song_op);
    }

    public void onSongPreviewClick(){
        if(isPlaying){
            mainMenuMusic.Play();
            bay.Stop();
            resolve.Stop();
            playText.GetComponent<TextMeshProUGUI>().text = "Play";
            isPlaying = false;
        }else{
            if(gc.song_op == 1){
                resolve.Play();
            }else{
                bay.Play();
            }
            mainMenuMusic.Stop();
            playText.GetComponent<TextMeshProUGUI>().text = "Stop";
            isPlaying = true;
        }
        
    }

    public void onSkinNext(){
        gc.skin_op++;
    }

    public void onSkinPrev(){
        gc.skin_op--;
    }
    
}
