using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelCompleteSceneController : MonoBehaviour
{

    public Button restartButton, nextButton, mainMenuButton;
    public TextMeshProUGUI heading, score;

    void Awake()
    {
        if (restartButton == null)
            throw new System.Exception("restartButton");
        restartButton.onClick.AddListener(RestartLevel);

        if (nextButton == null)
            throw new System.Exception("nextButton");
        nextButton.onClick.AddListener(NextLevel);

        if (mainMenuButton == null)
            throw new System.Exception("mainMenuButton");
        mainMenuButton.onClick.AddListener(ExitToMainMenu);

    }

    void Start()
    {
        Singleton singleton = Singleton.Instance;
        if (singleton != null)
        {
            singleton.CurrentLevelComplete();

            if (singleton.CurrentLevel >= 6)
            {
                nextButton.interactable = false;
            }

            if (heading != null)
            {
                heading.text = $"Level {singleton.CurrentLevel} Complete";
            }

            if (score != null)
            {
                score.text = $"Completed: {Mathf.Round(singleton.CompletionPercentage)}%";
            }

        }
    }

    void RestartLevel()
    {
        Singleton singleton = Singleton.Instance;
        if (singleton != null)
        {
            SceneManager.LoadScene("Level " + singleton.CurrentLevel);
        }
        else
            SceneManager.LoadScene("MainMenu");
    }

    void NextLevel()
    {
        Singleton singleton = Singleton.Instance;
        if (singleton != null && singleton.CurrentLevel < 6)
        {
            singleton.CurrentLevel += 1;
            SceneManager.LoadScene("Level " + singleton.CurrentLevel);
        }
        else
            SceneManager.LoadScene("MainMenu");
    }

    void ExitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
