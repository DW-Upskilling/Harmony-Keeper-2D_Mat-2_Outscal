using UnityEngine;

using Outscal.UnityFundamentals.Mat2.GenericClasses.MVC;
using Outscal.UnityFundamentals.Mat2.ScriptableObjects;
using Outscal.UnityFundamentals.Mat2.Events;
using Outscal.UnityFundamentals.Mat2.Entities.Player;
using Outscal.UnityFundamentals.Mat2.Level;

namespace Outscal.UnityFundamentals.Mat2.Entities.Animal
{
    public class AnimalController: Controller<AnimalModel, AnimalScriptableObject, AnimalView> 
    {
        public bool IsAlive { get { return model.isAlive; } private set {model.isAlive = value; } }
        public int IsGrounded { get { return model.isGrounded; } private set { model.isGrounded = value; } }
        public bool IsMoving { get { return model.isMoving; } private set { model.isMoving = value; } }
        public Vector2 Direction { get { return model.direction; } private set { model.direction = value; } }
        public float Speed { get { return model.ScriptableObject.Speed; } }

        protected AnimalService service { get; set; }

        private RaycastHit2D raycastHit2D { get; set; }
        private float sleep;
        private float awake;

        public AnimalController(AnimalScriptableObject animalScriptableObject, AnimalService animalService) : base(animalScriptableObject)
        {
            service = animalService;
            view = service.gameObject.GetComponent<AnimalView>();
            view.Controller = this;

            sleep = 0f;
            awake = 0f;
        }

        internal void Start()
        {
            IsAlive = true;
            view.enabled = true;
        }

        internal void Update()
        {
            if (!IsAlive)
                return;

            if (IsGrounded > 0)
            {
                patrol();
            }

            awake -= Time.deltaTime;
            if (awake > 0)
                return;

            sleep -= Time.deltaTime;

            if (awake <= 0 && sleep > 0)
            {
                IsMoving = false;
            }
            else
            {
                IsMoving = true;
                awake = Random.Range(0f, model.ScriptableObject.CooldownSeconds);
                sleep = Random.Range(0f, model.ScriptableObject.CooldownSeconds);
            }
        }

        internal void OnCollisionEnter2D(Collision2D collision2D)
        {
            if (collision2D.gameObject.GetComponent<IGround>() != null) {
                IsGrounded += 1;
            }
            else if (collision2D.gameObject.GetComponent<IPlayer>() != null)
            {
                kill();
            }
        }

        internal void OnCollisionExit2D(Collision2D collision2D)
        {
            if (collision2D.gameObject.GetComponent<IGround>() != null) {
                IsGrounded -= 1;
            }
        }

        protected override AnimalModel CreateModel(AnimalScriptableObject animalScriptableObject)
        {
            return new AnimalModel(animalScriptableObject);
        }
        protected override AnimalView InstantiateView(AnimalScriptableObject animalScriptableObject)
        {
            return null;
        }

        private void patrol() {
            raycastHit2D = Physics2D.Raycast(view.groundDetector.position, Vector2.down, model.ScriptableObject.ViewDistance);

            if (!raycastHit2D.collider || raycastHit2D.collider.gameObject.GetComponent<IGround>() == null)
                Direction = (Direction == Vector2.right) ? Vector2.left : Vector2.right;
        }
        
        private void kill()
        {
            AnimalKillEventHandler.Instance.TriggerAnimalKillEvent(this);
            
            IsAlive = false;
            GameObject.Destroy(view.rigidbody2d);
            view.boxCollider2D.enabled = false;
            view.PlayDead();
        }
    }
}