using System.Collections;
using UnityEngine;


namespace Outscal.UnityFundamentals.Mat2.GenericClasses.MVC
{
    public abstract class Controller<M, S, V> where M: Model<S> where S: ScriptableObject
    {
        protected M model { get; set; }
        public V view { get; protected set; }

        public Controller(S scriptableObject)
        {
            model = CreateCharacterModel(scriptableObject);
            view = InstantiateCharacterView(scriptableObject);
        }

        protected abstract M CreateCharacterModel(S scriptableObject);
        protected abstract V InstantiateCharacterView(S scriptableObject);
    }
}