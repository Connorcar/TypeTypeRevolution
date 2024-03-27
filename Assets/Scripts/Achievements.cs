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

    // Start is called before the first frame update
    void Start()
    {
        // Set all achievements to locked
        foreach (Image achievementIcon in achievementIcons)
        {
            achievementIcon.gameObject.SetActive(false);
        }
        foreach (TextMeshProUGUI achievementTitle in achievementTitles)
        {
            achievementTitle.color = Color.red;
        }
        LoadAchievements();
    }

    // Function to unlock achievement
    public void UnlockAchievement(string achievementName, bool newAchievement)
    {
        // if (!achievements.ContainsKey(achievementName))
        // {
        //     achievements.Add(achievementName, true);
            // Display achievement unlocked message
            ShowAchievementUnlocked(achievementName, newAchievement);
            PlayerPrefs.SetInt(achievementName, 1);
            PlayerPrefs.Save();
        //}
    }

    public void ShowAchievementUnlocked(string achievementName, bool newAchievement)
    {
        int i = 0;
        foreach (TextMeshProUGUI achievementTitle in achievementTitles)
        {
            if (achievementTitle.text == achievementName)
            {
                achievementTitle.color = Color.green;
                if(achievementIcons[i].gameObject.activeSelf == false){
                    achievementIcons[i].gameObject.SetActive(true);
                    // if (newAchievement)
                    // {
                    //     game.AchievementsPopup(achievementIcons[i], achievementTitle);
                    // }
                }
            }
            i++;
        }
    }

    public void onAchievementClick(int i)
    {
        // Display achievement unlocked message
        UnlockAchievement("Thing " + i, true);
    }

    public void clearAchievements()
    {
        PlayerPrefs.DeleteAll();
        foreach (Image achievementIcon in achievementIcons)
        {
            achievementIcon.gameObject.SetActive(false);
        }
        foreach (TextMeshProUGUI achievementTitle in achievementTitles)
        {
            achievementTitle.color = Color.red;
        }
    }

    public void LoadAchievements()
    {
        foreach (TextMeshProUGUI achievementTitle in achievementTitles)
        {
            if (PlayerPrefs.GetInt(achievementTitle.text) == 1)
            {
                UnlockAchievement(achievementTitle.text, false);
            }
        }
        PlayerPrefs.Save();
    }

};

