using UnityEngine;

using Outscal.UnityFundamentals.Mat2.GenericClasses.MVC;

namespace Outscal.UnityFundamentals.Mat2.Level.Platform
{
    public class PlatformView : View<PlatformController>, IPlatform, IGround
    {
        internal SpriteRenderer spriteRenderer;

        private void Awake()
        {
            // Get or add a SpriteRenderer component to the game object
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            if (spriteRenderer == null)
                spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        }

        private void OnCollisionEnter2D(Collision2D collision2D)
        {
            Controller.OnCollisionEnter2D(collision2D);
        }

        public bool CanActivate()
        {
            return Controller.CanActivate;
        }

    }
}