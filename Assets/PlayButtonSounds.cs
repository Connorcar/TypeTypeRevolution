using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonSounds : MonoBehaviour
{
    private GameObject g;
    private Game game;

    public AudioClip defaultHit;
    public AudioClip farmHit;
    public AudioClip oceanHit;
    public AudioClip winterHit;
    public AudioClip evilHit;

    private void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
        g = GameObject.Find("GameController");
        game = g.GetComponent<Game>();
    }

    void PlaySound()
    {
       
        switch (game.theme_op)
        {
            case 0:
                audio.clip = defaultHit;
                break;
            case 1:
                audio.clip = defaultHit;
                break;
            case 2:
                audio.clip = defaultHit;
                break;
            case 3:
                audio.clip = defaultHit;
                break;
            case 4:
                audio.clip = efaultHit;
                break;
        }
        audio.Play();
    }

    
}
