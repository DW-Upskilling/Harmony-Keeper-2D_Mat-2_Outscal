using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    private static Singleton instance;
    public static Singleton Instance { get { return instance; } }

    private int initialLaunch = 0;
    public int InitialLaunch { get { return initialLaunch; } }

    private int currentLevel = 0;
    public int CurrentLevel { set { currentLevel = value; } get { return currentLevel; } }

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        initialLaunch = PlayerPrefs.GetInt("InitialLaunch", 0);

        // Setting Initial Level as Unlocked
        if (PlayerPrefs.GetInt("1", 0) == 0 || initialLaunch == 0)
        {
            PlayerPrefs.SetInt("1", 1);
        }
    }

    public void CurrentLevelComplete()
    {
        PlayerPrefs.SetInt(currentLevel.ToString(), 2);
        PlayerPrefs.SetInt((currentLevel + 1).ToString(), 1);
    }


}
