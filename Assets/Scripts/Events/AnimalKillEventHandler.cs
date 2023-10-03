using System;

using Outscal.UnityFundamentals.Mat2.GenericClasses.Observer;
using Outscal.UnityFundamentals.Mat2.Entities.Animal;

namespace Outscal.UnityFundamentals.Mat2.Events
{
    public class AnimalKillEventHandler : SceneObserver<AnimalKillEventHandler, AnimalController>
    {
        public int animalsKilled { get; private set; }

        protected override void Initialize()
        {
            animalsKilled = 0;
        }

        public void TriggerKillEvent(AnimalController animalController)
        {
            if (!animalController.IsAlive)
                return;

            animalsKilled++;
            base.TriggerEvent(animalController);
        }
    }
}