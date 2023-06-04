using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public GameObject platforms, animals;

    public void UpdateScore()
    {
        Singleton singleton = Singleton.Instance;
        if (singleton != null && platforms != null && animals != null)
            singleton.CompletionCalculator(platforms, animals);
    }

    public void GoalReached()
    {
        SceneManager.LoadScene("LevelComplete");
    }

}
