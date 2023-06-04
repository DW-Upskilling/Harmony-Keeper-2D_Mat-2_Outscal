using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public GameObject platforms; // Reference to the platforms game object
    public GameObject animals; // Reference to the animals game object

    public void UpdateScore()
    {
        // Get the Singleton instance
        Singleton singleton = Singleton.Instance;

        // Check if Singleton instance and the platforms and animals objects are not null
        if (singleton != null && platforms != null && animals != null)
        {
            // Call the CompletionCalculator method in the Singleton instance
            singleton.CompletionCalculator(platforms, animals);

            // Goal is active only if all platforms are covered
            GoalController goalController = gameObject.GetComponentInChildren<GoalController>();
            if (goalController != null && singleton.LevelCompletionPercentage >= 100f)
            {
                goalController.IsReady = true;
            }
        }
    }

    public void GoalReached()
    {
        // Load the "LevelComplete" scene
        SceneManager.LoadScene("LevelComplete");
    }
}
