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

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        g = GameObject.Find("GameController");
        game = g.GetComponent<Game>();
    }

    public void PlaySound()
    {
        switch (game.theme_op)
        {
            case 0:
                audioSource.clip = defaultHit;
                break;
            case 1:
                audioSource.clip = farmHit;
                break;
            case 2:
                audioSource.clip = oceanHit;
                break;
            case 3:
                audioSource.clip = winterHit;
                break;
            case 4:
                audioSource.clip = evilHit;
                break;
        }
        audioSource.Play();
    }

    
}
