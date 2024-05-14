using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementManager : MonoBehaviour
{
    public Game game;
    public string theme = "Default"; 
    public string difficulty = "easy";
    public string song = "Bay";
    
    static public int numAchievements = 30;
    private int achievementsUnlocked = 0;
    public int numSkinsUnlocked = 1;
    //public bool[] achievements = new bool[numAchievements];
    public Dictionary<string, bool> achievements = new Dictionary<string, bool>();
    public Sprite achievementSprite;
    public Image achievementIcon;


    void Start(){   

        achievements.Add("Failed Score in the Default Theme", false);
        achievements.Add("Okay Score in the Default Theme", false);
        achievements.Add("Golden Score in the Default Theme", false);
        achievements.Add("Perfect Score in the Default Theme", false);
        achievements.Add("Played the Default Theme", false);

        achievements.Add("Failed Score in the Ocean Theme", false);
        achievements.Add("Okay Score in the Ocean Theme", false);
        achievements.Add("Golden Score in the Ocean Theme", false);
        achievements.Add("Perfect Score in the Ocean Theme", false);
        achievements.Add("Played the Ocean Theme", false);

        achievements.Add("Failed Score in the Farm Theme", false);
        achievements.Add("Okay Score in the Farm Theme", false);
        achievements.Add("Golden Score in the Farm Theme", false);
        achievements.Add("Perfect Score in the Farm Theme", false);
        achievements.Add("Played the Farm Theme", false);

        achievements.Add("Failed Score in the Winter Theme", false);
        achievements.Add("Okay Score in the Winter Theme", false);
        achievements.Add("Golden Score in the Winter Theme", false);
        achievements.Add("Perfect Score in the Winter Theme", false);
        achievements.Add("Played the Winter Theme", false);

        achievements.Add("Failed Score in the Evil Theme", false);
        achievements.Add("Okay Score in the Evil Theme", false);
        achievements.Add("Golden Score in the Evil Theme", false);
        achievements.Add("Perfect Score in the Evil Theme", false);
        achievements.Add("Played the Evil Theme", false);

        achievements.Add("Scored Perfect in All Themes", false);
        achievements.Add("Played All the Themes", false);
        achievements.Add("Played All the Difficulties", false);
        achievements.Add("Played All the Songs", false);
        achievements.Add("Unlocked All Achievements", false);

        //this list is for internal use only, controls unlockables
        achievements.Add("playedEasyInternal", false);
        achievements.Add("playedNormalInternal", false);
        achievements.Add("playedHardInternal", false);
        achievements.Add("playedDemonInternal", false);
        achievements.Add("playedBayInternal", false);
        achievements.Add("playedResolveInternal", false);

        Debug.Log("Achievements initialized to false");

        achievementIcon.sprite = achievementSprite;   
    }

    public void UnlockAchievement(string achievement)
    {
        string achievementName = achievement;
        //check if it is a score related achievement
        if(achievement.Contains("All") == false && achievement.Contains("Played") == false && achievement.Contains("played") == false){
            achievementName = achievement + " Score in the "+ theme + " Theme";
        }
        
        Debug.Log("checking for " + achievementName);
        if(achievements.ContainsKey(achievementName))
        {
            //if already unlocked, return
            if(achievements[achievementName] == true)
            {
                Debug.Log("already unlocked" + achievementName);
                if(achievement.Contains("all") == false && achievement.Contains("played") == false && achievement.Contains("Played") == false && achievement.Contains("All") == false){
                    checkNonScoreAchievements();
                }
                return;
            }else{
                achievements[achievementName] = true; 
                Debug.Log("unlocking achievement " + achievementName);
                if(achievement.Contains("Internal") == false){
                    game.AchievementsPopup(achievementIcon, achievementName);
                    achievementsUnlocked++;
                } 
                PlayerPrefs.SetInt(achievementName, 1);
                PlayerPrefs.Save();
                checkNonScoreAchievements();       
            }            
        }else{
            Debug.Log("Achievement not found");
            printAchievements();
        }
    }

    public void checkAllThemes()
    {
        Debug.Log("checking all themes");
        
        if(achievements["Played the Default Theme"] == true && achievements["Played the Ocean Theme"] == true && achievements["Played the Farm Theme"] == true && achievements["Played the Winter Theme"] == true && achievements["Played the Evil Theme"] == true && achievements["Played All the Themes"] == false)
        {
            Debug.Log("all themes played");
            unlockSkin();
            UnlockAchievement("Played All the Themes" );
            
        }else{
            if(achievements["Played the Default Theme"] == false){
            Debug.Log("default not played");
            }
            if(achievements["Played the Ocean Theme"] == false){
                Debug.Log("ocean not played");
            }
            if(achievements["Played the Farm Theme"] == false){
                Debug.Log("farm not played");
            }
            if(achievements["Played the Winter Theme"] == false){
                Debug.Log("winter not played");
            }
            if(achievements["Played the Evil Theme"] == false){
                Debug.Log("evil not played");
            }
        }
    }
    public void checkAllPerfect(){
        if(achievements["Perfect Score in the Default Theme"] == true && achievements["Perfect Score in the Ocean Theme"] == true && achievements["Perfect Score in the Farm Theme"] == true && achievements["Perfect Score in the Winter Theme"] == true && achievements["Perfect Score in the Evil Theme"] == true && achievements["Scored Perfect in All Themes"] == false)
        {
            unlockSkin();
            UnlockAchievement("Scored Perfect in All Themes" );
            
        }else{
            if(achievements["Perfect Score in the Default Theme"] == false){
            Debug.Log("default not perfect");
            }
            if(achievements["Perfect Score in the Ocean Theme"] == false){
                Debug.Log("ocean not perfect");
            }
            if(achievements["Perfect Score in the Farm Theme"] == false){
                Debug.Log("farm not perfect");
            }
            if(achievements["Perfect Score in the Winter Theme"] == false){
                Debug.Log("winter not perfect");
            }
            if(achievements["Perfect Score in the Evil Theme"] == false){
                Debug.Log("evil not perfect");
            }
        }
    }
    public void checkAllDifficulties(){
        
        if(achievements["playedEasyInternal"] == true && achievements["playedNormalInternal"] == true && achievements["playedHardInternal"] == true && achievements["playedDemonInternal"] == true && achievements["Played All the Difficulties"] == false)
        {
            unlockSkin();
            UnlockAchievement("Played All the Difficulties");
            
        }else{
            if(achievements["playedEasyInternal"] == false){
            Debug.Log("easy not played");
            }
            if(achievements["playedNormalInternal"] == false){
                Debug.Log("normal not played");
            }
            if(achievements["playedHardInternal"] == false){
                Debug.Log("hard not played");
            }
            if(achievements["playedDemonInternal"] == false){
                Debug.Log("demon not played");
            }
        }
    }
    public void checkAllSongs(){
        if(achievements["playedBayInternal"] == true && achievements["playedResolveInternal"] == true && achievements["Played All the Songs"] == false)
        {
            unlockSkin();
            UnlockAchievement("Played All the Songs");
            
        }else{
            if(achievements["playedBayInternal"] == false){
            Debug.Log("bay not played");
            }
            if(achievements["playedResolveInternal"] == false){
                Debug.Log("resolve not played");
            }
        }
    }
    public void checkAllAchievements(){
        if(achievementsUnlocked == numAchievements && achievements["Unlocked All Achievements"] == false)
        {
            UnlockAchievement("Unlocked All Achievements");
            //unlockSkin();
        }
    }
    public void checkIfPlayed(string theme){
        if(theme == "Default"){
            if(achievements["Played the Default Theme"] == false){
                UnlockAchievement("Played the Default Theme" );
            }
        }else if(theme == "Ocean"){
            if(achievements["Played the Ocean Theme"] == false){
                UnlockAchievement("Played the Ocean Theme" );
            }
        }else if(theme == "Farm"){
            if(achievements["Played the Farm Theme"] == false){
                UnlockAchievement("Played the Farm Theme" );
            }
        }else if(theme == "Winter"){
            if(achievements["Played the Winter Theme"] == false){
                UnlockAchievement("Played the Winter Theme" );
            }
        }else if(theme == "Evil"){
            if(achievements["Played the Evil Theme"] == false){
                UnlockAchievement("Played the Evil Theme" );
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
        theme = char.ToUpper(theme[0]) + theme.Substring(1);
        Debug.Log("current theme is " + theme);
    }
    public void setDifficulty(string newDifficulty){
        difficulty = newDifficulty.ToLower();
        Debug.Log("current difficulty is " + difficulty);
    }
    public void setSong(int newSong){
        if(newSong == 0){
            song = "Bay";
        }else{
            song = "Resolve";
        }
        Debug.Log("current song is " + song);
    }

    public void printAchievements(){
        foreach (KeyValuePair<string, bool> kvp in achievements)
        {
            Debug.Log("Key = " + kvp.Key + ", Value = " + kvp.Value);
        }
    }

    public int getNumSkinsUnlocked(){
        return numSkinsUnlocked;
    }

    public void unlockSkin(){
        numSkinsUnlocked++;
        Debug.Log("skins unlocked: " + numSkinsUnlocked);
    }

    public void checkNonScoreAchievements(){
        checkIfPlayed(theme);
            if(PartialMatch("Perfect")){
                checkAllPerfect();
            }

            if(song == "bay"){
                UnlockAchievement("playedBayInternal");
            }else{
                UnlockAchievement("playedResolveInternal");
            }

            if(difficulty == "easy"){
                UnlockAchievement("playedEasyInternal");
            }else if(difficulty == "norm"){
                UnlockAchievement("playedNormalInternal");
            }else if(difficulty == "hard"){
                UnlockAchievement("playedHardInternal");
            }else if(difficulty == "demon"){
                UnlockAchievement("playedDemonInternal");
            }

            if(PartialMatch("played") || PartialMatch("Played")){
                checkAllThemes();
                checkAllAchievements();
                checkAllDifficulties();
                checkAllSongs();
            }
    }

}