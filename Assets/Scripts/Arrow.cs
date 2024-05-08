/*
Arisa Takenaka Trombley
2375446
trombley@chapman.edu
CPSC-340-02
Type Type Revolution
*/

/* DESCRIPTION
Contains methods that handle key input for the "arrows"
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Arrow : MonoBehaviour
{
    public bool isFullyTyped;
    public bool canBePressed;
    public TMPro.TextMeshPro wordoutput;
    public int Num;

    public Sprite[] arrowSprites;
    private SpriteRenderer sr;

    public Canvas pauseMenu;
    
    private Game game;
    private WordBank wordBank;
    private ArrowSpawner arrowSpawner;
    private GameObject g;
    private GameObject wb;
    private GameObject AS;
    private GameObject Sound;
    private GameSounds gs;
    private KeyCode keyToPress;
    
    // Start is called before the first frame update
    void Start()
    {
        g = GameObject.Find("GameController");
        wb = GameObject.Find("WordBank");
        AS = GameObject.Find("ArrowSpawner");
        Sound = GameObject.Find("SoundEffects");
        gs = Sound.GetComponent<GameSounds>();
        arrowSpawner = AS.GetComponent<ArrowSpawner>();
        game = g.GetComponent<Game>();
        sr = this.GetComponent<SpriteRenderer>();
        wordBank = wb.GetComponent<WordBank>();
        wordoutput = GameObject.Find("Output").GetComponent<TMPro.TextMeshPro>();
        pauseMenu = GameObject.Find("Canvas-PauseMenu").GetComponent<Canvas>();
        switch (Num)
        {
            case 1:
                keyToPress = KeyCode.Alpha1;
                break;
            case 2:
                keyToPress = KeyCode.Alpha2;
                break;
            case 3:
                keyToPress = KeyCode.Alpha3;
                break;
            case 4:
                keyToPress = KeyCode.Alpha4;
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress) && pauseMenu.enabled == false)
        {
            if (canBePressed && isFullyTyped)
            {
                
                // StartCoroutine(DestroyDelay());         

                if (Mathf.Abs(transform.position.y - 5.55f) < 1 &&
                    Mathf.Abs(transform.position.y - 5.55f) > 0.35)
                {
                    Debug.Log("Good Hit " + Math.Abs(transform.position.y - 5.55f));
                    game.GoodHit();
                }
                else if (Mathf.Abs(transform.position.y - 5.55f) <= 0.35)
                {
                    Debug.Log("Perfect " + Math.Abs(transform.position.y - 5.55f));
                    game.PerfectHit();
                }
                else
                {
                    Debug.Log("Miss");
                    game.NoteMiss();
                }

                switch (keyToPress)
                {
                    case KeyCode.Alpha1:
                        gs.playOne();
                        sr.sprite = arrowSprites[0];
                        arrowSpawner.playParticleEffect(1);
                        break;
                    case KeyCode.Alpha2:
                        gs.playTwo();
                        sr.sprite = arrowSprites[1];
                        arrowSpawner.playParticleEffect(2);
                        break;
                    case KeyCode.Alpha3:
                        gs.playThree();
                        sr.sprite = arrowSprites[2];
                        arrowSpawner.playParticleEffect(3);
                        break;
                    case KeyCode.Alpha4:
                        gs.playFour();
                        sr.sprite = arrowSprites[3];
                        arrowSpawner.playParticleEffect(4);
                        break;
                }

                Destroy(gameObject);
                arrowSpawner.removeArrow(); 

            }
        }

        if (wordoutput == null)
        {
            wordoutput = GameObject.Find("Output").GetComponent<TMPro.TextMeshPro>();
        }
    }

    // @param other Collider2D that represents an object that enters the Collider
    // Method that handles collisions 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    public IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
        arrowSpawner.removeArrow();
    }
}
