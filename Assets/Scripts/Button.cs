/*
Arisa Takenaka Trombley
2375446
trombley@chapman.edu
CPSC-340-02
Type Type Revolution
*/

/* DESCRIPTION
Contains methods that handles the buttons on the main menu including "next" and "back" buttons
*/

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Cache = UnityEngine.Cache;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour 
{
    
    public Canvas MainMenu;
    public Canvas Options;
    // public Canvas TrophyCase;
    public GameObject CountDownBackground;
    public AudioSource goSound;
    public AudioSource mainMenuMusic;
    public SwipeController CDswipeController;
    
    
    private GameObject Countdown;
    private TextMeshProUGUI countdownText;
    private GameObject g;
    private Game game;
    
    // Start is called before the first frame update
    void Awake()
    {
        // MainMenu.GetComponent<Canvas>().enabled = true;
        // Options.GetComponent<Canvas>().enabled = false;
        // TrophyCase.GetComponent<Canvas>().enabled = false;
        enable(MainMenu.GetComponent<Canvas>());
        disable(Options.GetComponent<Canvas>());
        // disable(TrophyCase.GetComponent<Canvas>());
        CountDownBackground.SetActive(false);
        
        Countdown = GameObject.Find("Countdown");
        // countdownText = Countdown.GetComponent<TextMeshProUGUI>();
        // countdownText.enabled = false;
        g = GameObject.Find("GameController");
        game = g.GetComponent<Game>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("helo");
            OnPlayClick();
        }
    }


    private IEnumerator LoadGame()
    {
        mainMenuMusic.Stop();
        goSound.Play();
        CountDownBackground.SetActive(true);
        // countdownText.enabled = true;
        yield return new WaitForSeconds(0.8f);
        CDswipeController.Next();
        // countdownText.text = "2";
        yield return new WaitForSeconds(0.8f);
        CDswipeController.Next();
        // countdownText.text = "1";
        yield return new WaitForSeconds(0.8f);
        // countdownText.text = "go";
        CDswipeController.Next();
        yield return new WaitForSeconds(0.8f);
        CDswipeController.Next();
        SceneManager.LoadScene("Game");
    }

    public void OnPlayClick()
    {
        // MainMenu.GetComponent<Canvas>().enabled = false;
        // Options.GetComponent<Canvas>().enabled = true;
        disable(MainMenu.GetComponent<Canvas>());
        enable(Options.GetComponent<Canvas>());
    }
    
    public void OnBackClick()
    {
        // if (Options.GetComponent<Canvas>().enabled)
        // {
        //     Options.GetComponent<Canvas>().enabled = false;
        //     MainMenu.GetComponent<Canvas>().enabled = true;
        // }
        // else if (TrophyCase.GetComponent<Canvas>().enabled)
        // {
        //     TrophyCase.GetComponent<Canvas>().enabled = false;
        //     MainMenu.GetComponent<Canvas>().enabled = true;
        // }
        if (isEnabled(Options.GetComponent<Canvas>()))
        {
            disable(Options.GetComponent<Canvas>());
            enable(MainMenu.GetComponent<Canvas>());
        }
        /*
        else if (isEnabled(TrophyCase.GetComponent<Canvas>()))
        {
            disable(TrophyCase.GetComponent<Canvas>());
            enable(MainMenu.GetComponent<Canvas>());
        }
        */
        // if (Options.GetComponent<Canvas>().enabled)
        // {
        //     Options.GetComponent<Canvas>().enabled = false;
        //     MainMenu.GetComponent<Canvas>().enabled = true;
        // }
    }

    public void onStartClick()
    {
        StartCoroutine(LoadGame());
    }

    /*
    public void onTrophyClick()
    {
        // MainMenu.GetComponent<Canvas>().enabled = false;
        // TrophyCase.GetComponent<Canvas>().enabled = true;
        disable(MainMenu.GetComponent<Canvas>());
        enable(TrophyCase.GetComponent<Canvas>());
    }
    */

    public bool isEnabled(Canvas canvas)
    {
        return canvas.GetComponent<Canvas>().GetComponent<CanvasGroup>().alpha == 1;
    }

    public void enable(Canvas canvas)
    {
        canvas.GetComponent<Canvas>().GetComponent<CanvasGroup>().alpha = 1;
        canvas.GetComponent<Canvas>().GetComponent<CanvasGroup>().interactable = true;
        canvas.GetComponent<Canvas>().GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void disable(Canvas canvas)
    {
        canvas.GetComponent<Canvas>().GetComponent<CanvasGroup>().alpha = 0;
        canvas.GetComponent<Canvas>().GetComponent<CanvasGroup>().interactable = false;
        canvas.GetComponent<Canvas>().GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void onQuitClick()
    {
        Application.Quit();
    }


}

