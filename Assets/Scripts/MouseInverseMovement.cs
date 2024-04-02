/*
Claudia Celio
23737804
celio@chapman.edu
CPSC-340-02
Type Type Revolution
*/

/* DESCRIPTION
moves grid relativley and inversely to player mouse movement
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInverseMovement : MonoBehaviour
{
    private float speed = 3f;
    private float movementMultiplier = -6f;
    private Vector3 initialOffset;

    void Start()
    {
        // Calculate the offset between initial position and mouse position
        Vector3 mousePosition = Input.mousePosition;
        Vector3 initialMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10f));
        initialOffset = transform.position - initialMousePosition;
    }

    void Update()
    {
        // Get the position of the mouse in screen coordinates
        Vector3 mousePosition = Input.mousePosition;
        mousePosition *= movementMultiplier;

        // Convert the screen coordinates to world coordinates
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10f));

        // Add the initial offset to the mouse position
        newPosition += initialOffset;

        // Update the object's position to the new position
        transform.position = Vector3.Lerp(transform.position, newPosition, speed * Time.deltaTime);


    }
}
