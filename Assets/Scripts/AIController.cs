using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{

    public float speed = 1f;
    public float rayDistance = .1f;
    public GameObject groundDetector;
    public LayerMask[] groundLayerMasks;

    Vector2 direction;
    bool isGrounded;
    Animator animator;

    void Start()
    {
        direction = Vector2.right;
        if (groundDetector == null)
            throw new System.Exception("groundDetector");
        isGrounded = false;

        Animator animator = gameObject.GetComponent<Animator>();
        if (animator == null)
            throw new System.Exception("animator");
    }

    void Update()
    {
        if (isGrounded)
        {
            MovementHandler();
        }
        else if (animator != null)
        {
            animator.Play("idle");
        }
    }

    void LateUpdate()
    {
        if (!isGrounded)
            return;

        Transform transform = gameObject.GetComponent<Transform>();

        Vector3 position = transform.position;
        position += (Vector3)(direction * speed * Time.deltaTime);

        Quaternion rotation = transform.rotation;
        rotation.y = (direction == Vector2.right) ? 180 : 0;

        transform.position = position;
        transform.rotation = rotation;

        if (animator != null)
            animator.Play("walk");
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        GameObject collisionObject = collision2D.gameObject;
        int collisionLayer = collisionObject.layer;
        bool isCollidingWithAllowedLayer = false;

        foreach (LayerMask layerMask in groundLayerMasks)
        {
            if (((1 << collisionLayer) & layerMask) != 0)
            {
                isCollidingWithAllowedLayer = true;
                break;
            }
        }

        if (isCollidingWithAllowedLayer)
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision2D)
    {
        GameObject collisionObject = collision2D.gameObject;
        int collisionLayer = collisionObject.layer;
        bool isCollidingWithAllowedLayer = false;

        foreach (LayerMask layerMask in groundLayerMasks)
        {
            if (((1 << collisionLayer) & layerMask) != 0)
            {
                isCollidingWithAllowedLayer = true;
                break;
            }
        }

        if (isCollidingWithAllowedLayer)
        {
            isGrounded = false;
        }
    }

    void MovementHandler()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(groundDetector.GetComponent<Transform>().position, Vector2.down, rayDistance);

        if (!raycastHit2D.collider)
        {
            direction = (direction == Vector2.right) ? Vector2.left : Vector2.right;
            return;
        }

        GameObject collisionObject = raycastHit2D.collider.gameObject;
        int collisionLayer = collisionObject.layer;
        bool isCollidingWithAllowedLayer = false;

        foreach (LayerMask layerMask in groundLayerMasks)
        {
            if (((1 << collisionLayer) & layerMask) != 0)
            {
                isCollidingWithAllowedLayer = true;
                break;
            }
        }

        if (!isCollidingWithAllowedLayer)
            direction = (direction == Vector2.right) ? Vector2.left : Vector2.right;
    }
}
