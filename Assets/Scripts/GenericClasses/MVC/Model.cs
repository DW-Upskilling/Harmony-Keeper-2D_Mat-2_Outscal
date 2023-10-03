using System.Collections;
using UnityEngine;


namespace Outscal.UnityFundamentals.Mat2.GenericClasses.MVC
{
    

    public abstract class Model<S> where S:ScriptableObject
    {
        public S ScriptableObject { get; private set; }

        public Model(S scriptableObject)
        {
            this.ScriptableObject = scriptableObject;
        }
    }
}