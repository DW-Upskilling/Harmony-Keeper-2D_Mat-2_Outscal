using System;
using System.Collections.Generic;
using UnityEngine;

using Outscal.UnityFundamentals.Mat2.GenericClasses.Singleton;
using Outscal.UnityFundamentals.Mat2.ScriptableObjects;
using Outscal.UnityFundamentals.Mat2.Entities.Animal;
using Outscal.UnityFundamentals.Mat2.Level.Platform;

using Outscal.UnityFundamentals.Mat2.Events;
using Outscal.UnityFundamentals.Mat2.Managers.Audio;

namespace Outscal.UnityFundamentals.Mat2.Managers
{
    internal class LevelManager : SingletonScene<LevelManager>
    {
        [SerializeField]
        private GameObject platforms;
        [SerializeField]
        public GameObject animals;

        [SerializeField]
        private GoalController goal;

        private GameManager gameManager;
        private AudioManager audioManager;

        private AnimalKillEventHandler animalKillEvent;
        private PlatformActivatedEventHandler platformActivatedEvent;

        private float animalsSavedPercentage;
        private float platformsActivatedPercentage;
        private float completionPercentage;

        protected override void Initialize()
        {
            gameManager = GameManager.Instance;
            if (gameManager == null)
                throw new MissingReferenceException("GameManager");

            audioManager = AudioManager.Instance;
            if (audioManager == null)
                throw new MissingReferenceException("AudioManager");
        }

        private void Start()
        {
            animalKillEvent = AnimalKillEventHandler.Instance;
            if (animalKillEvent == null)
                throw new MissingReferenceException("AnimalKillEventHandler");

            platformActivatedEvent = PlatformActivatedEventHandler.Instance;
            if (platformActivatedEvent == null)
                throw new MissingReferenceException("PlatformActivatedEventHandler");

            animalKillEvent.AddListener(ScoreUpdate);
            platformActivatedEvent.AddListener(ScoreUpdate);
        }

        private void OnDestroy()
        {
            if (animalKillEvent != null)
                animalKillEvent.RemoveListener(ScoreUpdate);
            if (platformActivatedEvent != null)
                platformActivatedEvent.RemoveListener(ScoreUpdate);
        }

        private void ScoreUpdate(AnimalController animalController) {
            audioManager.Play("Death");
            calculateCompletionPercentage(); 
        }
        private void ScoreUpdate(PlatformController platformController)
        {
            audioManager.Play("Shoot");
            calculateCompletionPercentage();
        }

        private void calculateCompletionPercentage()
        {
            float totalAnimals = animals.GetComponentsInChildren<IAnimal>().Length;
            float animalsAlive = totalAnimals - animalKillEvent.animalsKilled;
            animalsSavedPercentage = totalAnimals > 0 ? (animalsAlive / totalAnimals) * 100 : 100;

            Debug.Log("Total: " + totalAnimals + "\tAlive: " + animalsAlive);

            List<IPlatform> results = new List<IPlatform>();
            platforms.GetComponentsInChildren<IPlatform>(true, results);
            float totalPlatforms = results.FindAll(e => e.CanActivate()).Count;
            float platformsActivated = platformActivatedEvent.platformsActivated;
            platformsActivatedPercentage = totalPlatforms > 0 ? ((totalPlatforms - platformsActivated) / totalPlatforms) * 100 : 100;

            Debug.Log("Total: " + totalPlatforms + "\tActivated: " + platformsActivated);

            completionPercentage = (animalsSavedPercentage + platformsActivatedPercentage) / 2;

            if (platformsActivatedPercentage >= 100f)
                goal.IsReady = true;
        }
        
    }
}
