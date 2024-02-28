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
    public GameObject CountDownBackground;
    public AudioSource goSound;

    private GameObject PlayButton;
    private GameObject Countdown;
    private TextMeshProUGUI countdownText;
    private GameObject g;
    private Game game;

    // Start is called before the first frame update
    void Awake()
    {
        MainMenu.GetComponent<Canvas>().enabled = true;
        Options.GetComponent<Canvas>().enabled = false;
        CountDownBackground.SetActive(false);
        PlayButton = GameObject.Find("Button-Play");
        Countdown = GameObject.Find("Countdown");
        g = GameObject.Find("GameController");
        game = g.GetComponent<Game>();
        countdownText = Countdown.GetComponent<TextMeshProUGUI>();
        countdownText.enabled = false;
    }


    private IEnumerator LoadGame()
    {
        goSound.Play();
        CountDownBackground.SetActive(true);
        countdownText.enabled = true;
        yield return new WaitForSeconds(0.8f);
        countdownText.text = "2";
        yield return new WaitForSeconds(0.8f);
        countdownText.text = "1";
        yield return new WaitForSeconds(0.8f);
        countdownText.text = "go";
        SceneManager.LoadScene("Game");
    }

    public void OnPlayClick()
    {
        MainMenu.GetComponent<Canvas>().enabled = false;
        Options.GetComponent<Canvas>().enabled = true;
    }
    
    public void OnBackClick()
    {
        if (Options.GetComponent<Canvas>().enabled)
        {
            Options.GetComponent<Canvas>().enabled = false;
            MainMenu.GetComponent<Canvas>().enabled = true;
        }
    }

    public void onStartClick()
    {
        StartCoroutine(LoadGame());
    }
}
