using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementManager : MonoBehaviour
{
    public Game game;
    public string theme = "default"; 
    
    static public int numAchievements = 27;
    //public bool[] achievements = new bool[numAchievements];
    public Dictionary<string, bool> achievements = new Dictionary<string, bool>();
    public Sprite achievementSprite;
    public Image achievementIcon;


    void Start(){   

        achievements.Add("faildefault", false);
        achievements.Add("okaydefault", false);
        achievements.Add("goldendefault", false);
        achievements.Add("perfectdefault", false);
        achievements.Add("playeddefault", false);

        achievements.Add("failocean", false);
        achievements.Add("okayocean", false);
        achievements.Add("goldenocean", false);
        achievements.Add("perfectocean", false);
        achievements.Add("playedocean", false);

        achievements.Add("failfarm", false);
        achievements.Add("okayfarm", false);
        achievements.Add("goldenfarm", false);
        achievements.Add("perfectfarm", false);
        achievements.Add("playedfarm", false);

        achievements.Add("failwinter", false);
        achievements.Add("okaywinter", false);
        achievements.Add("goldenwinter", false);
        achievements.Add("perfectwinter", false);
        achievements.Add("playedwinter", false);

        achievements.Add("failevil", false);
        achievements.Add("okayevil", false);
        achievements.Add("goldenevil", false);
        achievements.Add("perfectevil", false);
        achievements.Add("playedevil", false);

        achievements.Add("allPerfect", false);
        achievements.Add("allThemes", false);

        achievementIcon.sprite = achievementSprite;   
    }

    public void UnlockAchievement(string score)
    {
        string achievementName = score;
        if(score.Contains("all") == false && score.Contains("played") == false){
            achievementName = score + theme;
        }
        
        Debug.Log("checking for " + achievementName);
        if(achievements.ContainsKey(achievementName))
        {
            //if already unlocked, return
            if(achievements[achievementName] == true)
            {
                Debug.Log("already unlocked");
                return;
            }else{
                achievements[achievementName] = true; 
                Debug.Log("unlocking achievement " + achievementName);
                if(!(score.Contains("all") && score.Contains("played"))){ // no popup for all themes or played
                    game.AchievementsPopup(achievementIcon, achievementName);
                }           
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
        }else{
            Debug.Log("Achievement not found");
            printAchievements();
        }
    }
    public void checkAllThemes()
    {
        if(achievements["playeddefault"] == true && achievements["playedocean"] == true && achievements["playedfarm"] == true && achievements["playedwinter"] == true && achievements["playedevil"] == true)
        {
            UnlockAchievement("allThemes" );
        }
    }
    public void checkAllPerfect(){
        if(achievements["perfectdefault"] == true && achievements["perfectocean"] == true && achievements["perfectfarm"] == true && achievements["perfectwinter"] == true && achievements["perfectevil"] == true)
        {
            UnlockAchievement("allPerfect" );
        }
    }
    public void checkIfPlayed(string theme){
        if(theme == "default"){
            if(achievements["playeddefault"] == false){
                UnlockAchievement("playeddefault" );
            }
        }else if(theme == "ocean"){
            if(achievements["playedocean"] == false){
                UnlockAchievement("playedocean" );
            }
        }else if(theme == "farm"){
            if(achievements["playedfarm"] == false){
                UnlockAchievement("playedfarm" );
            }
        }else if(theme == "winter"){
            if(achievements["playedwinter"] == false){
                UnlockAchievement("playedwinter" );
            }
        }else if(theme == "evil"){
            if(achievements["playedevil"] == false){
                UnlockAchievement("playedevil" );
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

    public void setTheme(string newTheme){
        theme = newTheme.ToLower();
        Debug.Log("current theme is " + theme);
    }

    public void printAchievements(){
        foreach (KeyValuePair<string, bool> kvp in achievements)
        {
            Debug.Log("Key = " + kvp.Key + ", Value = " + kvp.Value);
        }
    }

}