using Outscal.UnityFundamentals.Mat2.GenericClasses.Observer;
using Outscal.UnityFundamentals.Mat2.Level.Platform;

namespace Outscal.UnityFundamentals.Mat2.Events
{
    public class PlatformActivatedEventHandler : SceneObserver<PlatformActivatedEventHandler, PlatformController>
    {
        public int platformsActivated { get; private set; }

        protected override void Initialize()
        {
            platformsActivated = 0;
        }

        public void TriggerPlatformActivateEvent(PlatformController platformController)
        {
            if (platformController.IsActivated)
                return;

            platformsActivated++;
            base.TriggerEvent(platformController);
        }
    }
}