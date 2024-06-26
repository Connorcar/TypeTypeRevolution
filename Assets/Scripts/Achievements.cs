using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Achievements : MonoBehaviour
{
    public Game game;
    public AchievementManager achievementManager;

    public Image[] achievementIcons;
    public TextMeshProUGUI[] achievementTitles;

    public SwipeController swipeController;

    // Start is called before the first frame update
    void Start()
    {
        // Set all achievements to locked
        foreach (Image achievementIcon in achievementIcons)
        {
            achievementIcon.color = new Color(255, 255, 255, 0);
        }
        foreach (TextMeshProUGUI achievementTitle in achievementTitles)
        {
            achievementTitle.color = new Color(255, 255, 255, 0);
        }
        LoadAchievements();
    }

    // Function to unlock achievement
    public void UnlockAchievement(string achievementName)
    {
        // if (!achievements.ContainsKey(achievementName))
        // {
        //     achievements.Add(achievementName, true);
            // Display achievement unlocked message
            ShowAchievementUnlocked(achievementName);
            achievementManager.achievements[achievementName] = true;
            PlayerPrefs.SetInt(achievementName, 1);
            PlayerPrefs.Save();
        //}
    }

    public void ShowAchievementUnlocked(string achievementName)
    {
        int i = 0;
        foreach (TextMeshProUGUI achievementTitle in achievementTitles)
        {
            if (achievementTitle.text == achievementName)
            {
                achievementTitle.color = new Color(255, 255, 255, 255);
                Debug.Log("Now Showing " + achievementName);
                //if(achievementIcons[i].gameObject.activeSelf == false){
                    //achievementIcons[i].gameObject.SetActive(true);
                    achievementIcons[i].color = new Color(255, 255, 255, 255);
                //}
                if(achievementTitle.text.Contains("All")){
                    achievementManager.unlockSkin();
                }
            }
            i++;
        }
    }

    public void onAchievementClick(int i)
    {
        // Display achievement unlocked message
        UnlockAchievement("Thing " + i);
    }

    public void clearAchievements()
    {
        Debug.Log("Clearing all achievements");
        PlayerPrefs.DeleteAll();
        foreach (Image achievementIcon in achievementIcons)
        {
            if(achievementIcon.color.a == 255){
                Debug.Log("Clearing an achievement");
                achievementIcon.color = new Color(255, 255, 255, 0);
            }
        }
        foreach (TextMeshProUGUI achievementTitle in achievementTitles)
        {
            achievementTitle.color = new Color(255, 255, 255, 0);
        }
        achievementManager.numSkinsUnlocked = 0;

        swipeController.ResetPage();
    }

    public void LoadAchievements()
    {
        foreach (TextMeshProUGUI achievementTitle in achievementTitles)
        {
            if (PlayerPrefs.GetInt(achievementTitle.text) == 1)
            {
                UnlockAchievement(achievementTitle.text);
                Debug.Log("Loaded " + achievementTitle.text);
            }
        }
        achievementManager.checkAllAchievements();
        achievementManager.checkAllThemes();
        achievementManager.checkAllDifficulties();
        achievementManager.checkAllSongs();
        achievementManager.checkAllPerfect();
        PlayerPrefs.Save();
    }

};

