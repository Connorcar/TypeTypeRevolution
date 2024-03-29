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
    
    public GameObject CustomPanel;
    private GameObject gameController;
    private Game gc;
    private AchievementManager am;
    
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
        "Default", "Ocean", "Winter", "Farm", "Evil"
    };

    private List<string> songArr = new List<string>()
    {
        "Bay", "Resolve"
    }; 

    private void Awake()
    {
        gameController = GameObject.Find("GameController");
        gc = gameController.GetComponent<Game>();
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
        }
        else
        {
            setPreset();
            setMode();
            setWL();
            setTheme();
            setSong();
        }
        
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
        gc.theme_op = gc.theme_op;
        themeText.GetComponent<TextMeshProUGUI>().text = themeArr[gc.theme_op];
        
    }

    public void onPresetNext()
    {
        CustomPanel.SetActive(false);
        int currIndex = presetArr.IndexOf(presetText.GetComponent<TextMeshProUGUI>().text);
        if (currIndex < 3)
        {
            presetText.GetComponent<TextMeshProUGUI>().text = presetArr[++currIndex];
        }
        else
        {
            currIndex = 3;
            presetText.GetComponent<TextMeshProUGUI>().text = presetArr[3];
        }

        modeText.GetComponent<TextMeshProUGUI>().text = modeArr[currIndex];
        WLText.GetComponent<TextMeshProUGUI>().text = WLArr[currIndex];

        changePresetColor(currIndex);
    }
    

    public void onPresetPrev()
    {
        CustomPanel.SetActive(false);
        int currIndex = presetArr.IndexOf(presetText.GetComponent<TextMeshProUGUI>().text);
        if (currIndex > 0)
        {
            presetText.GetComponent<TextMeshProUGUI>().text = presetArr[--currIndex];
        }
        else
        {
            currIndex = 0;
            presetText.GetComponent<TextMeshProUGUI>().text = presetArr[0];
        }
        
        modeText.GetComponent<TextMeshProUGUI>().text = modeArr[currIndex];
        WLText.GetComponent<TextMeshProUGUI>().text = WLArr[currIndex];
        
        changePresetColor(currIndex);
    }
    
    private void changePresetColor(int currIndex)
    {
        gc.speed_op = currIndex;
        gc.letter_op = currIndex;
    }


    public void onModeNext()
    {
        
        int currIndex = modeArr.IndexOf(modeText.GetComponent<TextMeshProUGUI>().text);
        if (currIndex < 3)
        {
            modeText.GetComponent<TextMeshProUGUI>().text = modeArr[++currIndex];
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
        
        int currIndex = modeArr.IndexOf(modeText.GetComponent<TextMeshProUGUI>().text);
        if (currIndex > 0)
        {
            modeText.GetComponent<TextMeshProUGUI>().text = modeArr[--currIndex];
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
        
        int currIndex = WLArr.IndexOf(WLText.GetComponent<TextMeshProUGUI>().text);
        if (currIndex < 3)
        {
            WLText.GetComponent<TextMeshProUGUI>().text = WLArr[++currIndex];
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
        
        int currIndex = WLArr.IndexOf(WLText.GetComponent<TextMeshProUGUI>().text);
        if (currIndex > 0)
        {
            WLText.GetComponent<TextMeshProUGUI>().text = WLArr[--currIndex];
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
        int currIndex = themeArr.IndexOf(themeText.GetComponent<TextMeshProUGUI>().text);
        if (currIndex < 4)
        {
            themeText.GetComponent<TextMeshProUGUI>().text = themeArr[++currIndex];
        }
        else
        {
            currIndex = 0;
            themeText.GetComponent<TextMeshProUGUI>().text = themeArr[0];
        }

        Debug.Log("current theme is " + themeText.GetComponent<TextMeshProUGUI>().text);
        am.setTheme(themeText.GetComponent<TextMeshProUGUI>().text);
        
        gc.theme_op = currIndex;
    }

    public void onThemePrev()
    {
        int currIndex = themeArr.IndexOf(themeText.GetComponent<TextMeshProUGUI>().text);
        if (currIndex > 0)
        {
            themeText.GetComponent<TextMeshProUGUI>().text = themeArr[--currIndex];
        }
        else
        {
            currIndex = 4;
            themeText.GetComponent<TextMeshProUGUI>().text = themeArr[4];
        }

        Debug.Log("current theme is " + themeText.GetComponent<TextMeshProUGUI>().text);
        am.setTheme(themeText.GetComponent<TextMeshProUGUI>().text);

        gc.theme_op = currIndex;
    }

    public void onSongNext()
    {
        int currIndex = songArr.IndexOf(songText.GetComponent<TextMeshProUGUI>().text);
        if (currIndex < 1)
        {
            themeText.GetComponent<TextMeshProUGUI>().text = themeArr[++currIndex];
        }
        
        gc.setAchievementColor(themeBacking.color);
        else
        {
            currIndex = 1;
            themeText.GetComponent<TextMeshProUGUI>().text = themeArr[1];
        }

        gc.song_op = currIndex;
    }

    public void onSongPrev()
    {
        int currIndex = songArr.IndexOf(songText.GetComponent<TextMeshProUGUI>().text);
        if (currIndex > 0)
        {
            songText.GetComponent<TextMeshProUGUI>().text = songArr[--currIndex];
        }
        else
        {
            currIndex = 0;
            songText.GetComponent<TextMeshProUGUI>().text = songArr[0];
        }

        gc.song_op = currIndex;
    }
    
}
