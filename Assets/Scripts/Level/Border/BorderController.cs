using UnityEngine;

using Outscal.UnityFundamentals.Mat2.GenericClasses.MVC;

namespace Outscal.UnityFundamentals.Mat2.Level.Border
{
    public class BorderController: Controller<BorderView> 
    {

        protected BorderService service { get; set; }

        public BorderController(BorderService borderService) : base()
        {
            service = borderService;
            view = service.gameObject.GetComponent<BorderView>();
            view.Controller = this;
        }

        internal void Start()
        {
            view.enabled = true;
        }

        internal void OnEnable()
        {
            view.edgeCollider2D.points = getBoxPoints();

            view.edgeCollider2D.enabled = true;
            view.boxCollider2D.enabled = false;
        }

        protected override BorderView InstantiateView()
        {
            return null;
        }

        private Vector2[] getBoxPoints()
        {
            
            Vector2 min = view.boxCollider2D.bounds.min;
            Vector2 max = view.boxCollider2D.bounds.max;

            // Calculate the corner points of the box collider
            Vector2 bottomLeft = new Vector2(min.x, min.y);
            Vector2 topLeft = new Vector2(min.x, max.y);
            Vector2 topRight = new Vector2(max.x, max.y);
            Vector2 bottomRight = new Vector2(max.x, min.y);

            // Create an array of points for the edge collider
            Vector2[] points = new Vector2[] { bottomLeft, topLeft, topRight, bottomRight, bottomLeft };

            return points;
        }
    }
}