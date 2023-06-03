using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    PlayerInputHandler inputHandler;

    void Awake()
    {
        inputHandler = gameObject.GetComponent<PlayerInputHandler>();

        if (inputHandler == null)
            throw new Exception("inputHandler");
    }

    void Update()
    {
        inputHandler.Handle();
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        GameObject collisionObject = collision2D.gameObject;

        AIController aIController = collisionObject.GetComponent<AIController>();

        if (aIController != null)
        {
            aIController.Kill();
        }
    }

}
