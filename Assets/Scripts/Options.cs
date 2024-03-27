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
    public GameObject PresetPanel;
    public TextMeshProUGUI presetText;
    private Image presetBacking;
    
    // Speed
    public GameObject ModePanel;
    public TextMeshProUGUI modeText;
    private Image modeBacking;
    
    // Word Length
    public GameObject WLPanel;
    public TextMeshProUGUI WLText;
    private Image WLBacking;

    // Theme
    public GameObject StylePanel;
    public TextMeshProUGUI themeText;
    private Image themeBacking;
    
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

    private void Awake()
    {
        gameController = GameObject.Find("GameController");
        gc = gameController.GetComponent<Game>();
        am = gameController.GetComponent<AchievementManager>();
        InitialSetup();
    }

    private void InitialSetup()
    {
        presetBacking = PresetPanel.GetComponent<Image>();
        modeBacking = ModePanel.GetComponent<Image>();
        WLBacking = WLPanel.GetComponent<Image>();
        themeBacking = StylePanel.GetComponent<Image>();
        if (gc.letter_op == 0 && gc.song_op == 0 &&
            gc.speed_op == 0 && gc.theme_op == 0)
        {
            CustomPanel.SetActive(false);
            presetText.GetComponent<TextMeshProUGUI>().text = presetArr[0];
            modeText.GetComponent<TextMeshProUGUI>().text = modeArr[0];
            WLText.GetComponent<TextMeshProUGUI>().text = WLArr[0];
            themeText.GetComponent<TextMeshProUGUI>().text = themeArr[0];

            presetBacking.color = Color.green;
            presetText.color = Color.black;
            
            modeBacking.color = Color.green;
            modeText.color = Color.black;

            WLBacking.color = Color.green;
            WLText.color = Color.black;

            themeBacking.color = Color.gray;
            themeText.color = Color.black;

            gc.speed_op = 0;
            gc.letter_op = 0;
            gc.theme_op = 0;
        }
        else
        {
            setPreset();
            setMode();
            setWL();
            setTheme();
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
        changeThemeColor(gc.theme_op);
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
            currIndex = 0;
            presetText.GetComponent<TextMeshProUGUI>().text = presetArr[0];
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
            currIndex = 3;
            presetText.GetComponent<TextMeshProUGUI>().text = presetArr[3];
        }
        
        modeText.GetComponent<TextMeshProUGUI>().text = modeArr[currIndex];
        WLText.GetComponent<TextMeshProUGUI>().text = WLArr[currIndex];
        
        changePresetColor(currIndex);
    }
    
    private void changePresetColor(int currIndex)
    {
        switch (currIndex)
        {
            case 0:
                presetBacking.color = Color.green;
                presetText.color = Color.black;
                modeBacking.color = Color.green;
                modeText.color = Color.black;
                WLBacking.color = Color.green;
                WLText.color = Color.black;
                break;
            case 1:
                presetBacking.color = Color.yellow;
                presetText.color = Color.black;
                modeBacking.color = Color.yellow;
                modeText.color = Color.black;
                WLBacking.color = Color.yellow;
                WLText.color = Color.black;
                break;
            case 2:
                presetBacking.color = Color.red;
                presetText.color = Color.black;
                modeBacking.color = Color.red;
                modeText.color = Color.black;
                WLBacking.color = Color.red;
                WLText.color = Color.black;
                break;
            case 3:
                presetBacking.color = Color.black;
                presetText.color = Color.white;
                modeBacking.color = Color.black;
                modeText.color = Color.white;
                WLBacking.color = Color.black;
                WLText.color = Color.white;
                break;
        }
        
        gc.speed_op = currIndex;
        gc.letter_op = currIndex;
    }


    public void onModeNext()
    {
        CustomPanel.SetActive(true);
        int currIndex = modeArr.IndexOf(modeText.GetComponent<TextMeshProUGUI>().text);
        if (currIndex < 3)
        {
            modeText.GetComponent<TextMeshProUGUI>().text = modeArr[++currIndex];
        }
        else
        {
            currIndex = 0;
            modeText.GetComponent<TextMeshProUGUI>().text = modeArr[0];
        }
        
        changeModeColor(currIndex);
    }

    public void onModePrev()
    {
        CustomPanel.SetActive(true);
        int currIndex = modeArr.IndexOf(modeText.GetComponent<TextMeshProUGUI>().text);
        if (currIndex > 0)
        {
            modeText.GetComponent<TextMeshProUGUI>().text = modeArr[--currIndex];
        }
        else
        {
            currIndex = 3;
            modeText.GetComponent<TextMeshProUGUI>().text = modeArr[3];
        }
        
        changeModeColor(currIndex);
    }

    private void changeModeColor(int currIndex)
    {
        switch (currIndex)
        {
            case 0:
                modeBacking.color = Color.green;
                modeText.color = Color.black;
                break;
            case 1:
                modeBacking.color = Color.yellow;
                modeText.color = Color.black;
                break;
            case 2:
                modeBacking.color = Color.red;
                modeText.color = Color.black;
                break;
            case 3:
                modeBacking.color = Color.black;
                modeText.color = Color.white;
                break;
        }

        gc.speed_op = currIndex;
    }

    public void onWLNext()
    {
        CustomPanel.SetActive(true);
        int currIndex = WLArr.IndexOf(WLText.GetComponent<TextMeshProUGUI>().text);
        if (currIndex < 3)
        {
            WLText.GetComponent<TextMeshProUGUI>().text = WLArr[++currIndex];
        }
        else
        {
            currIndex = 0;
            WLText.GetComponent<TextMeshProUGUI>().text = WLArr[0];
        }

        changeWLColor(currIndex);
    }

    public void onWLPrev()
    {
        CustomPanel.SetActive(true);
        int currIndex = WLArr.IndexOf(WLText.GetComponent<TextMeshProUGUI>().text);
        if (currIndex > 0)
        {
            WLText.GetComponent<TextMeshProUGUI>().text = WLArr[--currIndex];
        }
        else
        {
            currIndex = 3;
            WLText.GetComponent<TextMeshProUGUI>().text = WLArr[3];
        }

        changeWLColor(currIndex);
    }

    private void changeWLColor(int currIndex)
    {
        switch (currIndex)
        {
            case 0:
                WLBacking.color = Color.green;
                WLText.color = Color.black;
                break;
            case 1:
                WLBacking.color = Color.yellow;
                WLText.color = Color.black;
                break;
            case 2:
                WLBacking.color = Color.red;
                WLText.color = Color.black;
                break;
            case 3:
                WLBacking.color = Color.black;
                WLText.color = Color.white;
                break;
        }
        gc.letter_op = currIndex;
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

        changeThemeColor(currIndex);
        Debug.Log("current theme is " + themeText.GetComponent<TextMeshProUGUI>().text);
        am.setTheme(themeText.GetComponent<TextMeshProUGUI>().text);
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

        changeThemeColor(currIndex);
        Debug.Log("current theme is " + themeText.GetComponent<TextMeshProUGUI>().text);
        am.setTheme(themeText.GetComponent<TextMeshProUGUI>().text);
    }

    private void changeThemeColor(int currIndex)
    {
        Color orange = new Color(1.0f, 0.64f, 0.0f);
        
        switch (currIndex)
        {
            case 0:
                themeBacking.color = Color.gray;
                themeText.color = Color.black;
                break;
            case 1:
                themeBacking.color = Color.blue;
                themeText.color = Color.white;
                break;
            case 2:
                themeBacking.color = Color.white;
                themeText.color = Color.black;
                break;
            case 3:
                themeBacking.color = orange;
                themeText.color = Color.black;
                break;
            case 4:
                themeBacking.color = Color.black;
                themeText.color = Color.white;
                break;
        }
        
        gc.theme_op = currIndex;
        gc.setAchievementColor(themeBacking.color);
    }
}
