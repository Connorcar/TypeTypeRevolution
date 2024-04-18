/*
Claudia Celio
23737804
celio@chapman.edu
CPSC-340-02
Type Type Revolution
*/

/* DESCRIPTION
Changes the animation clips of the dancer in relation to specific keyboard input
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangePose : MonoBehaviour
{
        public Animator animator; // Reference to the Animator component
        //public AnimationClip newAnimationClip; // The new animation clip you want to play

    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "MainMenu")
        {
            Debug.Log("main menu pose");
            ChangeClip("SELECT");
        }
        if(currentScene.name == "Game")
        {
            Debug.Log("game pose");
            ChangeClip("IDLE");
        }
        if (currentScene.name == "Score")
        {
            Debug.Log("result pose");
            ChangeClip("RESULT");
        }
    }

    void Update()
        {
            // Check if the number 1 key is pressed
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                // Change the animation clip
                ChangeClip("PRESS 1");
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ChangeClip("PRESS 2");
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                ChangeClip("PRESS 3");
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                ChangeClip("PRESS 4");
            }


            //FOR TESTING PURPOSES
            /*if (Input.GetKeyDown(KeyCode.Space))
            {
                ChangeClip("SELECT");
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                ChangeClip("RESULT");
            }

            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                ChangeClip("DAB");
            }*/

           
        }

        void ChangeClip(string clipName)
        {
            // Check if the Animator component and the new animation clip are assigned
            if (animator != null)
            {
                // Change the current animation clip
                animator.Play(clipName);
            }
            else
            {
                Debug.LogError("Animator component or new animation clip is not assigned!");
            }
        }


}
