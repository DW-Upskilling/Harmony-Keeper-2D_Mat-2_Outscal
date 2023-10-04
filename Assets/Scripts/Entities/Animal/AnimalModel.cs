using UnityEngine;

using Outscal.UnityFundamentals.Mat2.GenericClasses.MVC;
using Outscal.UnityFundamentals.Mat2.ScriptableObjects;

namespace Outscal.UnityFundamentals.Mat2.Entities.Animal
{
    public class AnimalModel: Model<AnimalScriptableObject>
    {
        public bool isAlive { get; set; }
        public int isGrounded { get; set; }
        public bool isMoving { get; set; }
        public Vector2 direction { get; set; }

        public AnimalModel(AnimalScriptableObject scriptableObject) : base(scriptableObject)
        {
            isAlive = false;
            isGrounded = 0;
            isMoving = false;

            direction = Vector2.left;
        }
    }
}