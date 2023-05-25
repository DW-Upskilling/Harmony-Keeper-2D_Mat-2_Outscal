using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    Animator animator;

    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void ToggleIsWalking()
    {
        animator.SetBool("isWalking", !animator.GetBool("isWalking"));
    }
}
