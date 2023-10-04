using UnityEngine;

using Outscal.UnityFundamentals.Mat2.GenericClasses.MVC;

namespace Outscal.UnityFundamentals.Mat2.Entities.Player
{
    public class PlayerSpriteView : View<PlayerController>
    {

        internal Animator animator;
        internal SpriteRenderer spriteRenderer;

        private void Awake()
        {
            animator = gameObject.GetComponent<Animator>();
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }

        public void ResetColliderPoints()
        { Controller.ResetColliderPoints(); }

        internal void PlayWalking()
        {
            animator.SetBool(Animator.StringToHash("isWalking"), true);
        }

        internal void StopWalking()
        {
            animator.SetBool(Animator.StringToHash("isWalking"), false);
        }

        internal void PlayJump()
        {
            animator.SetTrigger(Animator.StringToHash("Jump"));
        }

        internal void PlayCrouch()
        {
            animator.SetTrigger(Animator.StringToHash("Crouch"));
        }
    }
}