using UnityEngine;

namespace Outscal.UnityFundamentals.Mat2.GenericClasses.Singleton
{
    public abstract class SingletonSession<T> : MonoBehaviour where T: SingletonSession<T>
    {
        public static T Instance { get; private set; }

        private void Awake()
        {
            if(Instance == null) {
                Instance = (T)this;
                DontDestroyOnLoad(gameObject);
                Initialize();
            } else {
                Destroy(gameObject);
            }
        }

        // method to make use of Awake functionality by derived classes
        protected abstract void Initialize();

    }
}