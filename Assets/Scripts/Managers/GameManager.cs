using System;
using UnityEngine;
using UnityEngine.SceneManagement;

using Outscal.UnityFundamentals.Mat2.GenericClasses.Singleton;
using Outscal.UnityFundamentals.Mat2.Utils;

namespace Outscal.UnityFundamentals.Mat2.Managers
{
    public class GameManager : SingletonSession<GameManager>
    {
        private int initialLaunch = 0;
        public int InitialLaunch { get { return initialLaunch; } set { initialLaunch = 1; } }

        private int currentLevel = 0;
        public int CurrentLevel { set { currentLevel = value; } get { return currentLevel; } }

        public int CompletionPercentage { get; private set; }

        private string levelKey;

        protected override void Initialize()
        {
            initialLaunch = PlayerPrefs.GetInt("InitialLaunch", 0);

            levelKey = Constants.LevelStatusKey(1);

            // Setting Initial Level as Unlocked
            if (PlayerPrefs.GetInt(levelKey, 0) == 0 || initialLaunch == 0)
            {
                PlayerPrefs.SetInt(levelKey, 1);
            }
        }

        internal void LevelComplete(int completionPercentage)
        {
            levelKey = Constants.LevelStatusKey(currentLevel);

            PlayerPrefs.SetInt(levelKey, completionPercentage >= 100 ? 3 : 2);

            levelKey = Constants.LevelStatusKey(currentLevel+1);
            // Unlock only if next level is not yet unlocked
            if (PlayerPrefs.GetInt(levelKey, 0) == 0)
                PlayerPrefs.SetInt(levelKey, 1);

            CompletionPercentage = completionPercentage;
        }

        internal void LevelReset() { }

        public void LoadScene(int sceneBuildIndex) {
            SceneManager.LoadScene(sceneBuildIndex);
        }
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

    }
}
