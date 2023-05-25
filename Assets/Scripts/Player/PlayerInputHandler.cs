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
        if (vertical != 0)
            MoveVertical(vertical);
    }

    void MoveHorizontal(float direction)
    {

        Debug.Log("PlayerInputHandler::MoveHorizontal(): direction: " + direction);

        Transform transform = gameObject.GetComponent<Transform>();
        Vector3 position = transform.position;
        Vector3 eulerAngles = transform.eulerAngles;

        if (direction > 0)
        {
            position.x += 1 * Time.deltaTime;
            eulerAngles.y = 0;
        }
        else
        {
            position.x -= 1 * Time.deltaTime;
            eulerAngles.y = 180;
        }

        transform.position = position;
        transform.eulerAngles = eulerAngles;

        animationHandler.ToggleIsWalking();
    }

    void MoveVertical(float direction)
    {

    }
}
