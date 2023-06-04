using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Sprite sprite; // Default sprite for the platform
    public Sprite OnTouchSprite; // Sprite to change to when the platform is touched

    private bool flagged; // Flag to track if the platform has been touched
    public bool Flagged { get { return flagged; } } // Property to get the flagged status

    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component

    void Awake()
    {
        // Get or add a SpriteRenderer component to the game object
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();

        // Check if the sprite is assigned, otherwise throw an exception
        if (sprite == null)
        {
            if (spriteRenderer.sprite == null)
                throw new System.Exception("sprite");
            else
                sprite = spriteRenderer.sprite;
        }

        flagged = false; // Set the flagged status to false initially
    }

    public void SpriteChange()
    {
        if (flagged)
            return;

        flagged = true; // Set the flagged status to true since the platform has been touched

        // Check if the OnTouchSprite is assigned, otherwise return
        if (OnTouchSprite == null)
            return;

        // Play the "Shoot" sound through the AudioManager if available
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.Play("Shoot");
        }

        // Get the SpriteRenderer component again in case it was modified in Awake()
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        // Change the sprite of the platform to the OnTouchSprite
        spriteRenderer.sprite = OnTouchSprite;

        // Get the LevelController component from the parent game object and update the score
        LevelController levelController = gameObject.GetComponentInParent<LevelController>();
        if (levelController != null)
            levelController.UpdateScore();
    }

    void Start()
    {
        spriteRenderer.sprite = sprite; // Set the default sprite when the platform starts
    }
}
