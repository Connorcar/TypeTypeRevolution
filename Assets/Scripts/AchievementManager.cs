using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementManager : MonoBehaviour
{
    public Game game;
    public string theme = "default"; 
    public string difficulty = "easy";
    public string song = "bay";
    
    static public int numAchievements = 30;
    private int achievementsUnlocked = 0;
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
        achievements.Add("allDifficulties", false);
        achievements.Add("allSongs", false);
        achievements.Add("allAchievements", false);

        //this list is for internal use only, controls unlockables
        achievements.Add("playedEasy", false);
        achievements.Add("playedNormal", false);
        achievements.Add("playedHard", false);
        achievements.Add("playedDemon", false);
        achievements.Add("playedBay", false);
        achievements.Add("playedResolve", false);

        achievementIcon.sprite = achievementSprite;   
    }

    public void UnlockAchievement(string achievement)
    {
        string achievementName = achievement;
        //check if it is a score related achievement
        if(achievement.Contains("all") == false && achievement.Contains("played") == false){
            achievementName = achievement + theme;
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
                //if(!(achievement.Contains("all") && achievement.Contains("played"))){ // no popup for all themes or played
                    game.AchievementsPopup(achievementIcon, achievementName);
                //}
                numAchievements++;        
            }
            checkIfPlayed(theme);
            if(PartialMatch("played")){
                checkAllThemes();
                checkAllAchievements();
                checkAllDifficulties();
                checkAllSongs();
            }
            if(PartialMatch("perfect")){
                checkAllPerfect();
            }

            if(song == "bay"){
                UnlockAchievement("playedBay");
            }else{
                UnlockAchievement("playedResolve");
            }

            if(difficulty == "easy"){
                UnlockAchievement("playedEasy");
            }else if(difficulty == "norm"){
                UnlockAchievement("playedNormal");
            }else if(difficulty == "hard"){
                UnlockAchievement("playedHard");
            }else if(difficulty == "demon"){
                UnlockAchievement("playedDemon");
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
    public void checkAllDifficulties(){
        if(achievements["playedEasy"] == true && achievements["playedNormal"] == true && achievements["playedHard"] == true && achievements["playedDemon"] == true)
        {
            UnlockAchievement("allDifficulties");
        }
    }
    public void checkAllSongs(){
        if(achievements["playedBay"] == true && achievements["playedResolve"] == true)
        {
            UnlockAchievement("allSongs");
        }
    }
    public void checkAllAchievements(){
        if(numAchievements == 30)
        {
            UnlockAchievement("allAchievements");
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
    public void setDifficulty(string newDifficulty){
        difficulty = newDifficulty.ToLower();
        Debug.Log("current difficulty is " + difficulty);
    }
    public void setSong(int newSong){
        if(newSong == 0){
            song = "bay";
        }else{
            song = "resolve";
        }
        Debug.Log("current song is " + song);
    }

    public void printAchievements(){
        foreach (KeyValuePair<string, bool> kvp in achievements)
        {
            Debug.Log("Key = " + kvp.Key + ", Value = " + kvp.Value);
        }
    }

}