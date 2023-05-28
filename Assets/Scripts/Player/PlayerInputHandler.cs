using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public GameObject playerSprite;
    public float maxJumpHeight = 0.8f;

    PlayerAnimationHandler animationHandler;

    bool isGrounded;

    void Awake()
    {
        if (playerSprite == null)
            throw new Exception("playerSprite");

        animationHandler = playerSprite.GetComponent<PlayerAnimationHandler>();
        if (animationHandler == null)
            throw new Exception("animationHandler");

        isGrounded = false;
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
        if (isGrounded)
            animationHandler.StartWalking();
        // Debug.Log("PlayerInputHandler::MoveHorizontal(): direction: " + direction);

        Transform transform = gameObject.GetComponent<Transform>();
        Vector3 position = transform.position;
        Vector3 eulerAngles = playerSprite.GetComponent<Transform>().eulerAngles;

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
        playerSprite.GetComponent<Transform>().eulerAngles = eulerAngles;
    }

    void MoveVertical(float direction)
    {
        Rigidbody2D rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        if (rigidbody2D == null)
            throw new Exception("rigidbody2D");
        if (direction > 0 && isGrounded)
        {
            animationHandler.TriggerJump();

            float maxHeight = transform.position.y + maxJumpHeight;
            float forceMagnitude = Mathf.Min(maxHeight - transform.position.y, direction);
            Vector2 jumpForce = Vector2.up * forceMagnitude;

            if ((transform.position.y + jumpForce.y) < maxHeight)
            {
                rigidbody2D.AddForce(jumpForce, ForceMode2D.Impulse);
            }
        }
        if (direction < 0 && isGrounded)
        {
            animationHandler.TriggerCrouch();
        }

    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        GameObject collisionObject = collision2D.gameObject;

        BorderController borderController = collisionObject.GetComponent<BorderController>();
        PlatformController platformController = collisionObject.GetComponent<PlatformController>();

        if (borderController != null || platformController != null)
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision2D)
    {
        GameObject collisionObject = collision2D.gameObject;

        BorderController borderController = collisionObject.GetComponent<BorderController>();
        PlatformController platformController = collisionObject.GetComponent<PlatformController>();

        if (borderController != null || platformController != null)
        {
            isGrounded = false;
        }
    }
}
