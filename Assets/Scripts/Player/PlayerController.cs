using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInputHandler inputHandler; // Reference to the PlayerInputHandler component

    void Awake()
    {
        inputHandler = gameObject.GetComponent<PlayerInputHandler>(); // Get the PlayerInputHandler component

        if (inputHandler == null)
            throw new Exception("inputHandler"); // Throw an exception if the inputHandler is not found
    }

    void Update()
    {
        inputHandler.Handle(); // Call the Handle method in the PlayerInputHandler to handle player input
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        GameObject collisionObject = collision2D.gameObject; // Get the game object collided with

        AIController aIController = collisionObject.GetComponent<AIController>(); // Get the AIController component from the collided game object

        if (aIController != null)
        {
            aIController.Kill(); // Call the Kill method in the AIController to eliminate the AI
        }
    }
}
