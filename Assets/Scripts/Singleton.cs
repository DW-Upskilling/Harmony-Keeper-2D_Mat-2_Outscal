using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    private static Singleton instance;
    public static Singleton Instance { get { return instance; } }

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        // Setting Initial Level as Unlocked
        PlayerPrefs.SetInt("Level 1", 2);
        PlayerPrefs.SetInt("Level 2", 1);
    }
}
