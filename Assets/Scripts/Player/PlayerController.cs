using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    PlayerAnimationHandler animationHandler;
    PlayerInputHandler inputHandler;

    void Awake()
    {
        animationHandler = gameObject.GetComponent<PlayerAnimationHandler>();
        inputHandler = gameObject.GetComponent<PlayerInputHandler>();

        if (animationHandler == null)
            throw new Exception("animationHandler");
        if (inputHandler == null)
            throw new Exception("inputHandler");
    }

    void Update()
    {
        inputHandler.Handle();
    }

}
