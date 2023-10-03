using UnityEngine;

namespace Outscal.UnityFundamentals.Mat2.GenericClasses.Singleton
{
    public abstract class SingletonScene<T> : MonoBehaviour where T: SingletonScene<T>
    {
        public static T Instance { get; private set; }

        private void Awake()
        {
            if(Instance == null) {
                Instance = (T)this;
                Initialize();
            } else {
                Destroy(gameObject);
            }
        }

        // method to make use of Awake functionality by derived classes
        protected abstract void Initialize();
    }
}