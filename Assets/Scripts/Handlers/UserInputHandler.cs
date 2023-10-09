using UnityEngine;

namespace Outscal.UnityFundamentals.Mat2.Handlers
{
    public class UserInputHandler
    {
        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }

        public void Handle()
        {
            Horizontal = Input.GetAxisRaw("Horizontal");
            Vertical = Input.GetAxisRaw("Vertical");
        }

    }
}
