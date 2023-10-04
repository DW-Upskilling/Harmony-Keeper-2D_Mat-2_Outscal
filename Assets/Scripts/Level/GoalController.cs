using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Outscal.UnityFundamentals.Mat2.Entities.Player;
using Outscal.UnityFundamentals.Mat2.Managers.Audio;
public class GoalController : MonoBehaviour
{

    private bool isReady = false;
    public bool IsReady
    {
        set
        {
            isReady = value;

            ParticleSystem particleSystem = gameObject.GetComponent<ParticleSystem>();
            if (particleSystem != null && !particleSystem.isPlaying && isReady)
            {
                particleSystem.Play();
            }
        }
    }

    void Start()
    {
        ParticleSystem particleSystem = gameObject.GetComponent<ParticleSystem>();
        if (particleSystem != null && particleSystem.isPlaying)
        {
            particleSystem.Pause();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (!isReady)
            return;

        // Play game over sound if AudioManager instance exists
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.Play("GameOver");
        }

        // Check if the collider is the player
        if (collider.GetComponent<IPlayer>() != null)
        {
            // Get the LevelController component in the parent object
            LevelController levelController = gameObject.GetComponentInParent<LevelController>();

            // Call the GoalReached method in the levelController
            levelController.GoalReached();
        }
    }
}
