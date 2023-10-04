using UnityEngine;

using Outscal.UnityFundamentals.Mat2.GenericClasses.MVC;
using Outscal.UnityFundamentals.Mat2.Level;
using Outscal.UnityFundamentals.Mat2.Handlers;

namespace Outscal.UnityFundamentals.Mat2.Entities.Player
{
    public class PlayerController : Controller<PlayerView> 
    {
        protected PlayerService service { get; set; }
        protected PlayerSpriteView spriteView { get; set; }

        private int isGrounded { get; set; }

        private UserInputHandler userInputHandler;

        private Vector3 Position;
        private Vector3 EulerAngles;

        public PlayerController(PlayerService playerService) : base()
        {
            service = playerService;

            view = service.gameObject.GetComponent<PlayerView>();
            view.Controller = this;

            spriteView = service.gameObject.GetComponentInChildren<PlayerSpriteView>();
            spriteView.Controller = this;

            userInputHandler = new UserInputHandler();

            isGrounded = 0;
        }

        internal void Start()
        {
            view.polygonCollider.enabled = true;
            ResetColliderPoints();
            
            view.enabled = true;
            spriteView.enabled = true;
        }

        internal void Update()
        {
            userInputHandler.Handle();

            float horizontal = userInputHandler.Horizontal;

            Position = view.gameObject.transform.position;
            Position.x += horizontal * 2f * Time.deltaTime;

            EulerAngles = spriteView.gameObject.transform.eulerAngles;
            EulerAngles.y = horizontal > 0f ? 0f : 180f;
        }

        internal void LateUpdate()
        {
            view.gameObject.transform.position = Position;
            spriteView.gameObject.transform.eulerAngles = EulerAngles;

            float horizontal = userInputHandler.Horizontal;
            float vertical = userInputHandler.Vertical;

            if (horizontal != 0)
            {
                spriteView.PlayWalking();
            }
            else
                spriteView.StopWalking();

            if (isGrounded >= 0)
            {
                if (vertical > 0)
                {
                    view.rigidbody2d.velocity = Vector2.up * 7f * vertical;
                    spriteView.PlayJump();
                }
                else if (vertical < 0)
                    spriteView.PlayCrouch();
            }
        }

        internal void OnCollisionEnter2D(Collision2D collision2D)
        {
            if (collision2D.gameObject.GetComponent<IGround>() != null) {
                isGrounded += 1;
            }
        }

        internal void OnCollisionExit2D(Collision2D collision2D)
        {
            if (collision2D.gameObject.GetComponent<IGround>() != null) {
                isGrounded -= 1;
            }
        }

        internal void ResetColliderPoints()
        {
            // Get the sprite's bounds
            Bounds spriteBounds = spriteView.spriteRenderer.sprite.bounds;

            // Calculate the collider points based on the sprite's bounds
            Vector2[] colliderPoints = new Vector2[4];
            colliderPoints[0] = new Vector2(spriteBounds.min.x, spriteBounds.min.y);
            colliderPoints[1] = new Vector2(spriteBounds.min.x, spriteBounds.max.y);
            colliderPoints[2] = new Vector2(spriteBounds.max.x, spriteBounds.max.y);
            colliderPoints[3] = new Vector2(spriteBounds.max.x, spriteBounds.min.y);

            // Assign the collider points to the PolygonCollider2D
            view.polygonCollider.points = colliderPoints;
        }

        protected override PlayerView InstantiateView()
        {
            return null;
        }

    }
}