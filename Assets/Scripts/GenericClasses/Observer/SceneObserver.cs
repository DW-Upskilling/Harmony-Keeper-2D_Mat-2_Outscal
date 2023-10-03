using System;

using Outscal.UnityFundamentals.Mat2.GenericClasses.Singleton;

namespace Outscal.UnityFundamentals.Mat2.GenericClasses.Observer
{
    public abstract class SceneObserver<C, T> : SingletonScene<C> where C : SceneObserver<C, T>
    {
        private event Action<T> ObserverQueue;

        public void AddListener(Action<T> listener)
        {
            ObserverQueue += listener;
        }

        public void RemoveListener(Action<T> listener)
        {
            ObserverQueue -= listener;
        }

        protected void TriggerEvent(T t)
        {
            ObserverQueue?.Invoke(t);
        }
    }
}