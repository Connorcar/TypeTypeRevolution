using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementManager : MonoBehaviour
{
    static public int numAchievements = 27;
    //public bool[] achievements = new bool[numAchievements];
    public Dictionary<string, bool> achievements = new Dictionary<string, bool>();
    public Image[] achievementIcons;

    void Start(){

        achievements.Add("failDefault", false);
        achievements.Add("okayDefault", false);
        achievements.Add("goldenDefault", false);
        achievements.Add("perfectDefault", false);
        achievements.Add("playedDefault", false);

        achievements.Add("failOcean", false);
        achievements.Add("okayOcean", false);
        achievements.Add("goldenOcean", false);
        achievements.Add("perfectOcean", false);
        achievements.Add("playedOcean", false);

        achievements.Add("failFarm", false);
        achievements.Add("okayFarm", false);
        achievements.Add("goldenFarm", false);
        achievements.Add("perfectFarm", false);
        achievements.Add("playedFarm", false);

        achievements.Add("failWinter", false);
        achievements.Add("okayWinter", false);
        achievements.Add("goldenWinter", false);
        achievements.Add("perfectWinter", false);
        achievements.Add("playedWinter", false);

        achievements.Add("failEvil", false);
        achievements.Add("okayEvil", false);
        achievements.Add("goldenEvil", false);
        achievements.Add("perfectEvil", false);
        achievements.Add("playedEvil", false);

        achievements.Add("allPerfect", false);
        achievements.Add("allThemes", false);
    }

    public void UnlockAchievement(string achievementName, string theme)
    {
        if(achievements.ContainsKey(achievementName))
        {
            //if already unlocked, return
            if(achievements[achievementName] == true)
            {
                return;
            }else{
                achievements[achievementName] = true;            
            }
            checkIfPlayed(theme);
            if(PartialMatch("played")){
                checkAllThemes();
            }
            if(PartialMatch("perfect")){
                checkAllPerfect();
            }
            PlayerPrefs.SetInt(achievementName, 1);
            PlayerPrefs.Save();
        }
    }
    public void checkAllThemes()
    {
        if(achievements["playedDefault"] == true && achievements["playedOcean"] == true && achievements["playedFarm"] == true && achievements["playedWinter"] == true && achievements["playedEvil"] == true)
        {
            UnlockAchievement("allThemes", "none");
        }
    }
    public void checkAllPerfect(){
        if(achievements["perfectDefault"] == true && achievements["perfectOcean"] == true && achievements["perfectFarm"] == true && achievements["perfectWinter"] == true && achievements["perfectEvil"] == true)
        {
            UnlockAchievement("allPerfect", "none");
        }
    }
    public void checkIfPlayed(string theme){
        if(theme == "default"){
            if(achievements["playedDefault"] == false){
                UnlockAchievement("playedDefault", "none");
            }
        }else if(theme == "ocean"){
            if(achievements["playedOcean"] == false){
                UnlockAchievement("playedOcean", "none");
            }
        }else if(theme == "farm"){
            if(achievements["playedFarm"] == false){
                UnlockAchievement("playedFarm", "none");
            }
        }else if(theme == "winter"){
            if(achievements["playedWinter"] == false){
                UnlockAchievement("playedWinter", "none");
            }
        }else if(theme == "evil"){
            if(achievements["playedEvil"] == false){
                UnlockAchievement("playedEvil", "none");
            }
        }
        return;
    }

    // Method to check if no achievement key contains the partial text
    public bool PartialMatch(string partialText)
    {
        foreach (string key in achievements.Keys)
        {
            if (key.Contains(partialText))
            {
                return true; // Return true if partial text is found
            }
        }
        return false; // Return false if partial text is not found
        
    }

}