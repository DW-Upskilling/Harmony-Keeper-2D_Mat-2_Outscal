using UnityEngine;

using Outscal.UnityFundamentals.Mat2.GenericClasses.MVC;

namespace Outscal.UnityFundamentals.Mat2.Level.Border
{
    public class BorderView : View<BorderController>, IBorder, IGround
    {

        internal BoxCollider2D boxCollider2D;
        internal EdgeCollider2D edgeCollider2D;

        private void Awake()
        {
            boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
            edgeCollider2D = gameObject.GetComponent<EdgeCollider2D>();
        }

        private void OnEnable()
        {
            Controller.OnEnable();
        }
    }
}