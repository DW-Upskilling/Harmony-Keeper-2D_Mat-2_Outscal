using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Outscal.UnityFundamentals.Mat2.Entities.Animal;

namespace Outscal.UnityFundamentals.Mat2.ScriptableObjects
{
    [CreateAssetMenu(fileName = "LevelScriptableObject", menuName = "ScriptableObjects/Level")]
    public class LevelScriptableObject : ScriptableObject
    {
        [SerializeField]
        private List<AnimalView> AnimalViewList;
    }
}
