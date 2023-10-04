using UnityEngine;

using Outscal.UnityFundamentals.Mat2.GenericClasses.MVC;

namespace Outscal.UnityFundamentals.Mat2.Entities.Player
{
    public class PlayerView : View<PlayerController>, IPlayer
    {
        internal PolygonCollider2D polygonCollider;
        internal Rigidbody2D rigidbody2d;

        private void Awake()
        {
            polygonCollider = gameObject.GetComponent<PolygonCollider2D>();
            rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Controller.Update();
        }

        private void LateUpdate()
        {
            Controller.LateUpdate();
        }

        private void OnCollisionEnter2D(Collision2D collision2D)
        {
            Controller.OnCollisionEnter2D(collision2D);
        }

        private void OnCollisionExit2D(Collision2D collision2D)
        {
            Controller.OnCollisionExit2D(collision2D);
        }
    }
}