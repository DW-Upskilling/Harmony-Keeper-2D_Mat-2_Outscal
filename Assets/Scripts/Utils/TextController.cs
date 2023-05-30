using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
    void OnDestroy()
    {
        Animator animator = gameObject.GetComponent<Animator>();
        if (animator != null)
        {
            animator.Play("fade");
        }
        Destroy(gameObject);
    }
}
