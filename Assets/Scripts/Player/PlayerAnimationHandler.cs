using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    Animator animator;
    PolygonCollider2D polygonCollider;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        if (animator == null)
            throw new Exception("animator");
        if (spriteRenderer == null)
            throw new Exception("spriteRenderer");

        polygonCollider = gameObject.GetComponentInParent<PolygonCollider2D>();
        if (polygonCollider == null)
        {
            GameObject parent = gameObject.GetComponent<Transform>().parent.gameObject;
            polygonCollider = parent.AddComponent<PolygonCollider2D>();
        }
        polygonCollider.enabled = true;

    }

    void Start()
    {
        ResetColliderPoints();
    }

    public void ResetColliderPoints()
    {
        // Get the sprite's bounds
        Bounds spriteBounds = spriteRenderer.sprite.bounds;

        // Calculate the collider points based on the sprite's bounds
        Vector2[] colliderPoints = new Vector2[4];
        colliderPoints[0] = new Vector2(spriteBounds.min.x, spriteBounds.min.y);
        colliderPoints[1] = new Vector2(spriteBounds.min.x, spriteBounds.max.y);
        colliderPoints[2] = new Vector2(spriteBounds.max.x, spriteBounds.max.y);
        colliderPoints[3] = new Vector2(spriteBounds.max.x, spriteBounds.min.y);

        // Assign the collider points to the PolygonCollider2D
        polygonCollider.points = colliderPoints;
    }

    public void StartWalking()
    {
        animator.SetBool("isWalking", true);
    }

    public void StopWalking()
    {
        animator.SetBool("isWalking", false);
    }

    public void TriggerJump()
    {
        animator.SetTrigger("Jump");
    }

    public void TriggerCrouch()
    {
        animator.SetTrigger("Crouch");
    }
}
