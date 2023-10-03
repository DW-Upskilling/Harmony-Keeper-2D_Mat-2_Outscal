using System.Collections;
using UnityEngine;


namespace Outscal.UnityFundamentals.Mat2.GenericClasses.MVC
{
    public abstract class View<C> : MonoBehaviour
    {
        public C Controller { get; internal set; }
    }
}