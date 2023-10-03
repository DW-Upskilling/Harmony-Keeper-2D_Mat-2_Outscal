using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Outscal.UnityFundamentals.Mat2.Entities.Animal;

namespace Outscal.UnityFundamentals.Mat2.ScriptableObjects.Animal
{
    [CreateAssetMenu(fileName = "AnimalListScriptableObject", menuName = "ScriptableObjects/AnimalList")]
    public class AnimalListScriptableObject : ScriptableObject
    {
        [SerializeField]
        private List<AnimalView> AnimalScriptableObject;
        
    }
}
