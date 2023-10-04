using System.Collections;
using UnityEngine;

using Outscal.UnityFundamentals.Mat2.GenericClasses.MVC;
using Outscal.UnityFundamentals.Mat2.ScriptableObjects;

namespace Outscal.UnityFundamentals.Mat2.Level.Platform
{
    public class PlatformModel : Model<PlatformScriptableObject>
    {
        public bool isActivated { get; set; }

        public PlatformModel(PlatformScriptableObject scriptableObject) : base(scriptableObject)
        {
            isActivated = false;
        }
    }
}