using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    private static Singleton instance;
    public static Singleton Instance { get { return instance; } }

    private int initialLaunch = 0;
    public int InitialLaunch { get { return initialLaunch; } set { initialLaunch = 1; } }

    private int currentLevel = 0;
    public int CurrentLevel { set { currentLevel = value; } get { return currentLevel; } }

    private float completionPercentage = 0f, platformsCoveredPercentage = 0f;
    public float CompletionPercentage { get { return completionPercentage; } }
    public float LevelCompletionPercentage { get { return platformsCoveredPercentage; } }

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        // Only for Development
        // Removed during Production
        // PlayerPrefs.DeleteAll();

        initialLaunch = PlayerPrefs.GetInt("InitialLaunch", 0);

        // Setting Initial Level as Unlocked
        if (PlayerPrefs.GetInt("1", 0) == 0 || initialLaunch == 0)
        {
            PlayerPrefs.SetInt("1", 1);
        }
    }

    public void CurrentLevelComplete()
    {
        PlayerPrefs.SetInt(currentLevel.ToString(), completionPercentage >= 100 ? 3 : 2);

        // Unlock only if next level is not yet unlocked
        if (PlayerPrefs.GetInt((currentLevel + 1).ToString(), 0) == 0)
            PlayerPrefs.SetInt((currentLevel + 1).ToString(), 1);
    }

    public void CompletionCalculator(GameObject platforms, GameObject animals)
    {
        
    }


}
