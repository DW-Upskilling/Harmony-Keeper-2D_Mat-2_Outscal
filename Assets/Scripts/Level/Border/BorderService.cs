using UnityEngine;

namespace Outscal.UnityFundamentals.Mat2.Level.Border
{
    public class BorderService : MonoBehaviour
    {

        private BorderController borderController;

        private void Awake()
        {
            borderController = new BorderController(this);
        }

        private void Start()
        {
            borderController.Start();
        }

    }
}

// Reference: https://www.youtube.com/watch?v=NbvcfMjAlQ4