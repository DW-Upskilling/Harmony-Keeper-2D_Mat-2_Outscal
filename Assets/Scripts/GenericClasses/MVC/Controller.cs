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
            model = CreateModel(scriptableObject);
            view = InstantiateView(scriptableObject);
        }

        protected abstract M CreateModel(S scriptableObject);
        protected abstract V InstantiateView(S scriptableObject);
    }

    public abstract class Controller<V>
    {
        public V view { get; protected set; }

        public Controller()
        {
            view = InstantiateView();
        }

        protected abstract V InstantiateView();
    }
}