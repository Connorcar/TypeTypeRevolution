/*
Arisa Takenaka Trombley
2375446
trombley@chapman.edu
CPSC-340-02
Type Type Revolution
*/

/* DESCRIPTION
Contains method that handles the "3, 2, 1, Go!" audio before starting game
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GO : MonoBehaviour
{
    public Canvas Options;
    public AudioSource goSound;

    // Update is called once per frame
    void Update()
    {
        if (Options.GetComponent<Canvas>().enabled)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                goSound.Play();
            }
        }
    }
}
