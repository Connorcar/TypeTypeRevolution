/*
Arisa Takenaka Trombley
2375446
trombley@chapman.edu
CPSC-340-02
Type Type Revolution
*/

/* DESCRIPTION
Contains methods that handle the blinking of the startText on the Main Menu
*/
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Blinker : MonoBehaviour
{
    public Canvas Options;
    // public TMP_Text startText;
    public Image startImage;
    
    private float blinkDuration = 1f;
    private bool isBlinking = false;
    
    // Start is called before the first frame update
    void Start()
    {
        startImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Options.GetComponent<Canvas>().enabled)
        {
            if (!isBlinking)
            {
                StartCoroutine("Blink");
            }
        }
    }

    private IEnumerator Blink()
    {
        isBlinking = true;
        startImage.CrossFadeAlpha(1, blinkDuration, false);
        yield return new WaitForSeconds(blinkDuration);
        startImage.CrossFadeAlpha(0.3f, blinkDuration, false);
        yield return new WaitForSeconds(blinkDuration);
        isBlinking = false;
    }
}
