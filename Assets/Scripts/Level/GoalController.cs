using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.Play("GameOver");
        }

        PlayerController playerController = collider.GetComponent<PlayerController>();

        if (playerController != null)
        {
            LevelController levelController = gameObject.GetComponentInParent<LevelController>();

            levelController.GoalReached();
        }
    }

}
