﻿using UnityEngine;

using Outscal.UnityFundamentals.Mat2.GenericClasses.MVC;

namespace Outscal.UnityFundamentals.Mat2.Entities.Animal
{
    public class AnimalView : View<AnimalController>, IAnimal
    {
        [SerializeField]
        internal Transform groundDetector;

        internal Animator animator;
        internal Rigidbody2D rigidbody2d;
        internal BoxCollider2D boxCollider2D;

        private void Awake()
        {
            animator = gameObject.GetComponent<Animator>();
            rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
            boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        }

        private void Update()
        {
            Controller.Update();
        }

        private void LateUpdate()
        {
            if (!Controller.IsMoving || !Controller.IsAlive)
            {
                animator.SetBool(Animator.StringToHash("walk"), false);
                return;
            }

            Transform transform = gameObject.GetComponent<Transform>();

            Vector2 direction = Controller.Direction;
            float speed = Controller.Speed;

            Vector3 position = transform.position;
            position += (Vector3)(direction * speed * Time.deltaTime);

            Quaternion rotation = transform.rotation;
            rotation.y = (direction == Vector2.right) ? 180 : 0;

            transform.position = position;
            transform.rotation = rotation;

            animator.SetBool(Animator.StringToHash("walk"), true);
        }

        private void OnCollisionEnter2D(Collision2D collision2D)
        {
            Controller.OnCollisionEnter2D(collision2D);
        }

        private void OnCollisionExit2D(Collision2D collision2D)
        {
            Controller.OnCollisionExit2D(collision2D);
        }
    
        internal void PlayDead()
        {
            animator.SetBool(Animator.StringToHash("dead"), true);
        }
    }
}