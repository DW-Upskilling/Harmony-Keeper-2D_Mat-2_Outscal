using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Outscal.UnityFundamentals.Mat2.Entities.Platform;

namespace Outscal.UnityFundamentals.Mat2.ScriptableObjects
{
    [CreateAssetMenu(fileName = "PlatformScriptableObject", menuName = "ScriptableObjects/Platform")]
    public class PlatformScriptableObject : ScriptableObject
    {
        [SerializeField]
        private PlatformType platformType;
        public PlatformType PlatformType { get { return platformType; } }

        [SerializeField]
        private PlatformSize platformSize;
        public PlatformSize PlatformSize { get { return platformSize; } }

        [SerializeField]
        private PhysicsMaterial2D physicsMaterial2D;
        public PhysicsMaterial2D PhysicsMaterial2D { get { return PhysicsMaterial2D; } }

        [SerializeField]
        private Sprite initialSprite;
        public Sprite InitialSprite { get { return initialSprite; } }

        [SerializeField]
        private Sprite activatedSprite;
        public Sprite ActivatedSprite { get { return activatedSprite; } }

        [SerializeField]
        private bool canActivate;
        public bool CanActivate { get { return canActivate; } }
    }
}
