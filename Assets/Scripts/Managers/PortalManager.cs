using UnityEngine;

using Outscal.UnityFundamentals.Mat2.GenericClasses.Singleton;
using Outscal.UnityFundamentals.Mat2.Entities.Player;

namespace Outscal.UnityFundamentals.Mat2.Managers
{
    public class PortalManager : SingletonScene<PortalManager>
    {

        private ParticleSystem ps;
        private BoxCollider2D boxCollider2D;
        
        internal void OpenPortal()
        {
            ps.Play();
            boxCollider2D.enabled = true;
        }

        protected override void Initialize()
        {
            ps = gameObject.GetComponent<ParticleSystem>();
            boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        }

        private void Start()
        {
            ps.Pause();
            boxCollider2D.enabled = false;
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.GetComponent<IPlayer>() != null) {
                LevelManager.Instance.LevelComplete();
            }
        }
    }
}
