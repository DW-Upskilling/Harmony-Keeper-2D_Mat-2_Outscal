using UnityEngine;

namespace Outscal.UnityFundamentals.Mat2.Entities.Player
{
    public class PlayerService : MonoBehaviour
    {
        private PlayerController playerController;

        private void Awake()
        {
            playerController = new PlayerController(this);
        }

        private void Start()
        {
            playerController.Start();
        }

    }
}