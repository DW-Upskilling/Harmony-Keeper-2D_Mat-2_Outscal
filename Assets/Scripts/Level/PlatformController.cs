using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Sprite sprite;

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
    }

    void Start()
    {
        spriteRenderer.sprite = sprite;
    }

}
