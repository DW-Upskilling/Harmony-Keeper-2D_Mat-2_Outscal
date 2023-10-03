using UnityEngine;

using Outscal.UnityFundamentals.Mat2.ScriptableObjects;

namespace Outscal.UnityFundamentals.Mat2.Entities.Platform
{
    public class PlatformService : MonoBehaviour
    {
        [SerializeField]
        private PlatformScriptableObject platformScriptableObject;

        private PlatformController platformController;

        private void Awake()
        {
            platformController = new PlatformController(platformScriptableObject, this);
        }

        private void Start()
        {
            platformController.Start();
        }

    }
}