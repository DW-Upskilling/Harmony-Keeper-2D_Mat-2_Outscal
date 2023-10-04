using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Outscal.UnityFundamentals.Mat2.Level;

public class PlayerInputHandler : MonoBehaviour
{
    public GameObject playerSprite;
    // public float maxJumpHeight = 0.8f;
    public float speed = 2f, jump = 1f;

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
        float vertical = Input.GetAxisRaw("Vertical");

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

        position.x = position.x + direction * speed * Time.deltaTime;

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

            rigidbody2D.velocity = Vector2.up * jump * direction;
        }
        if (direction < 0 && isGrounded)
        {
            animationHandler.TriggerCrouch();
        }

    }

    void OnCollisionStay2D(Collision2D collision2D)
    {
        GameObject collisionObject = collision2D.gameObject;

        if (collisionObject.GetComponent<IGround>() != null)
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision2D)
    {
        GameObject collisionObject = collision2D.gameObject;

        if (collisionObject.GetComponent<IGround>() != null)
        {
            isGrounded = false;
        }
    }
}
