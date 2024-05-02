using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySounds : MonoBehaviour
{
    int currDifficulty;
    int maxDifficulty;

    public string setting;

    public AudioSource bloop;

    GameObject gameController;
    Game gc;

    public float[] bloopPitchValues = { 0.75f, 0.80f, 0.84f, 0.87f };

    // Start is called before the first frame update
    void Start()
    { 
        currDifficulty = 0;
        maxDifficulty = 3;

        gameController = GameObject.Find("GameController");
        gc = gameController.GetComponent<Game>();

        currDifficulty = gc.speed_op;
    }

    public void OnLeftArrow()
    {
        if (currDifficulty <= 0)
        {
            currDifficulty = 0;
        }
        else
        {
            currDifficulty--;
        }
        PlayBloop();
    }

    public void OnRightArrow()
    {
        if (currDifficulty >= maxDifficulty)
        {
            currDifficulty = maxDifficulty;
        }
        else
        {
            currDifficulty++;
        }
        PlayBloop();
    }

    public void PlayBloop()
    {
        if (setting == "Preset")
        {
            bloop.pitch = bloopPitchValues[gc.speed_op];
        }
        else if (setting == "Speed")
        {
            bloop.pitch = bloopPitchValues[gc.speed_op];
        }
        else if (setting == "Letter")
        {
            bloop.pitch = bloopPitchValues[gc.letter_op];
        }

        bloop.Play();
    }
}
