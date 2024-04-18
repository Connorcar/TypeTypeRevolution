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
    public int numSkinsUnlocked = 0;
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

        achievements.Add("allperfect", false);
        achievements.Add("allthemes", false);
        achievements.Add("alldifficulties", false);
        achievements.Add("allsongs", false);
        achievements.Add("allachievements", false);

        //this list is for internal use only, controls unlockables
        achievements.Add("playedEasyInternal", false);
        achievements.Add("playedNormalInternal", false);
        achievements.Add("playedHardInternal", false);
        achievements.Add("playedDemonInternal", false);
        achievements.Add("playedBayInternal", false);
        achievements.Add("playedResolveInternal", false);

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
                if(achievement.Contains("all") == false && achievement.Contains("played") == false){
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
        
        if(achievements["playeddefault"] == true && achievements["playedocean"] == true && achievements["playedfarm"] == true && achievements["playedwinter"] == true && achievements["playedevil"] == true && achievements["allthemes"] == false)
        {
            Debug.Log("all themes played");
            UnlockAchievement("allthemes" );
            unlockSkin();
        }else{
            if(achievements["playeddefault"] == false){
            Debug.Log("default not played");
            }
            if(achievements["playedocean"] == false){
                Debug.Log("ocean not played");
            }
            if(achievements["playedfarm"] == false){
                Debug.Log("farm not played");
            }
            if(achievements["playedwinter"] == false){
                Debug.Log("winter not played");
            }
            if(achievements["playedevil"] == false){
                Debug.Log("evil not played");
            }
        }
    }
    public void checkAllPerfect(){
        if(achievements["perfectdefault"] == true && achievements["perfectocean"] == true && achievements["perfectfarm"] == true && achievements["perfectwinter"] == true && achievements["perfectevil"] == true && achievements["allperfect"] == false)
        {
            UnlockAchievement("allperfect" );
            unlockSkin();
        }else{
            if(achievements["perfectdefault"] == false){
            Debug.Log("default not perfect");
            }
            if(achievements["perfectocean"] == false){
                Debug.Log("ocean not perfect");
            }
            if(achievements["perfectfarm"] == false){
                Debug.Log("farm not perfect");
            }
            if(achievements["perfectwinter"] == false){
                Debug.Log("winter not perfect");
            }
            if(achievements["perfectevil"] == false){
                Debug.Log("evil not perfect");
            }
        }
    }
    public void checkAllDifficulties(){
        
        if(achievements["playedEasyInternal"] == true && achievements["playedNormalInternal"] == true && achievements["playedHardInternal"] == true && achievements["playedDemonInternal"] == true && achievements["alldifficulties"] == false)
        {
            UnlockAchievement("alldifficulties");
            unlockSkin();
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
        if(achievements["playedBayInternal"] == true && achievements["playedResolveInternal"] == true && achievements["allsongs"] == false)
        {
            UnlockAchievement("allsongs");
            unlockSkin();
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
        if(achievementsUnlocked == numAchievements && achievements["allachievements"] == false)
        {
            UnlockAchievement("allachievements");
            unlockSkin();
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

    public int getNumSkinsUnlocked(){
        return numSkinsUnlocked;
    }

    public void unlockSkin(){
        numSkinsUnlocked++;
        Debug.Log("skins unlocked: " + numSkinsUnlocked);
    }

    public void checkNonScoreAchievements(){
        checkIfPlayed(theme);
            if(PartialMatch("perfect")){
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

            if(PartialMatch("played")){
                checkAllThemes();
                checkAllAchievements();
                checkAllDifficulties();
                checkAllSongs();
            }
    }

}