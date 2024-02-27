/*
Arisa Takenaka Trombley
2375446
trombley@chapman.edu
CPSC-340-02
Type Type Revolution
*/

/* DESCRIPTION
Contains methods that handle the Pause menu in the game
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public Canvas PauseMenu;
    
    private Game game;
    private GameObject gc;
    
    void Start()
    {
        PauseMenu.enabled = false;
        gc = GameObject.Find("GameController");
        game = gc.GetComponent<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            PauseGame();
            PauseMenu.enabled = true;
        }
    }

    public void onHomeClick()
    {
        SceneManager.LoadScene("Main");
        Time.timeScale = 1;
    }

    public void onResumeClick()
    {
        PauseMenu.enabled = false;
        Time.timeScale = 1;
    }

    public void onRestartClick()
    {
        SceneManager.LoadScene("Game");
        game.ResetGame();
        Time.timeScale = 1;
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
    }
}