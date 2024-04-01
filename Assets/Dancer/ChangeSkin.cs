using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkin : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component
    public RuntimeAnimatorController[] animatorControllers; // Array of animator controllers to be switched

    public void ChangeController(int controllerIndex)
    {
        // Check if the Animator component and the animatorControllers array are assigned
        if (animator != null && animatorControllers != null && controllerIndex >= 0 && controllerIndex < animatorControllers.Length)
        {
            // Change the animator controller
            animator.runtimeAnimatorController = animatorControllers[controllerIndex];
            animator.Play("IDLE");
        }
        else
        {
            Debug.LogError("Animator component or animatorControllers array is not assigned, or index is out of range!");
        }
    }
}
