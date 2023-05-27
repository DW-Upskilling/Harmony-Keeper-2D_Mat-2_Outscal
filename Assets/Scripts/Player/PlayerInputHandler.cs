using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    PlayerAnimationHandler animationHandler;

    void Awake()
    {
        animationHandler = gameObject.GetComponent<PlayerAnimationHandler>();

        if (animationHandler == null)
            throw new Exception("animationHandler");
    }

    public void Handle()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal != 0)
            MoveHorizontal(horizontal);
        else
            animationHandler.StopWalking();

        if (vertical != 0)
            MoveVertical(vertical);
    }

    void MoveHorizontal(float direction)
    {
        animationHandler.StartWalking();
        Debug.Log("PlayerInputHandler::MoveHorizontal(): direction: " + direction);

        Transform transform = gameObject.GetComponent<Transform>();
        Vector3 position = transform.position;
        Vector3 eulerAngles = transform.eulerAngles;

        position.x = position.x + direction * Time.deltaTime;

        if (direction > 0)
        {
            eulerAngles.y = 0;
        }
        else
        {
            eulerAngles.y = 180;
        }

        transform.position = position;
        transform.eulerAngles = eulerAngles;
    }

    void MoveVertical(float direction)
    {
        if (direction > 0)
        {
            animationHandler.TriggerJump();
        }

    }
}
