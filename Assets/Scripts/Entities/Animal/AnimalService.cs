using System.Collections;
using UnityEngine;

using Outscal.UnityFundamentals.Mat2.ScriptableObjects;

namespace Outscal.UnityFundamentals.Mat2.Entities.Animal
{
    public class AnimalService : MonoBehaviour
    {
        [SerializeField]
        private AnimalScriptableObject animalScriptableObject;

        private AnimalController animalController;

        private void Awake()
        {
            animalController = new AnimalController(animalScriptableObject, this);
        }

        private void Start()
        {
            animalController.Start();
        }

    }
}