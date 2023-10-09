using System.Collections.Generic;
using UnityEngine;

namespace Outscal.UnityFundamentals.Mat2.ScriptableObjects
{
    [CreateAssetMenu(fileName = "AnimalScriptableObject", menuName = "ScriptableObjects/Animal")]
    public class AnimalScriptableObject : ScriptableObject
    {
        [SerializeField]
        private float speed;
        public float Speed { get { return speed; } }

        [SerializeField]
        private float viewDistance;
        public float ViewDistance { get { return viewDistance; } }

        [SerializeField]
        private float cooldownSeconds;
        public float CooldownSeconds { get { return cooldownSeconds; } }

        [SerializeField]
        private List<Sprite> orderedSprites;
        public List<Sprite> OrderedSprites { get { return orderedSprites; } }
    }
}
