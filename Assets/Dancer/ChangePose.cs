using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePose : MonoBehaviour
{
        public Animator animator; // Reference to the Animator component
        public AnimationClip newAnimationClip; // The new animation clip you want to play

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
            if (Input.GetKeyDown(KeyCode.Space))
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
            }
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
