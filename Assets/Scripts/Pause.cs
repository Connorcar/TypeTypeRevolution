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
    public Music music;
    
    private Game game;
    private GameObject gc;
    
    void Start()
    {
        PauseMenu.enabled = false;
        gc = GameObject.Find("GameController");
        game = gc.GetComponent<Game>();
        music = GameObject.Find("Music").GetComponent<Music>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (PauseMenu.enabled == false)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    private void PauseGame()
    {
        PauseMenu.enabled = true;
        Time.timeScale = 0;
        music.PauseMusic();
    }

    public void ResumeGame()
    {
        PauseMenu.enabled = false;
        Time.timeScale = 1;
        music.PlayMusic();
    }

    public void onRestartClick()
    {
        SceneManager.LoadScene("Game");
        game.ResetGame();
        Time.timeScale = 1;
    }

    public void onHomeClick()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}
