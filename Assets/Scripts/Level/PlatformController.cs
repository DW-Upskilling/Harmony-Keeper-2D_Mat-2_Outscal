using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Sprite sprite, OnTouchSprite;
    private bool flagged;
    public bool Flagged { get { return flagged; } }

    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();

        if (sprite == null)
            if (spriteRenderer.sprite == null)
                throw new System.Exception("sprite");
            else
                sprite = spriteRenderer.sprite;

        flagged = false;
    }

    public void SpriteChange()
    {
        if (flagged)
            return;
        flagged = true;

        if (OnTouchSprite == null)
            return;

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.Play("Shoot");
        }

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = OnTouchSprite;

        LevelController levelController = gameObject.GetComponentInParent<LevelController>();
        if (levelController != null)
            levelController.UpdateScore();
    }

    void Start()
    {
        spriteRenderer.sprite = sprite;
    }

}
