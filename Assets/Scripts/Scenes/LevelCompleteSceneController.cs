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

        Singleton singleton = Singleton.Instance;
        if (singleton != null)
        {
            if (heading != null)
            {
                heading.text = $"Level {singleton.CurrentLevel} Complete";
            }
        }
    }

    void Start()
    {
        Singleton singleton = Singleton.Instance;
        if (singleton != null)
        {
            singleton.CurrentLevelComplete();

            if (heading != null)
            {
                heading.text = $"Level {singleton.CurrentLevel} Complete";
            }
        }
    }

    void RestartLevel()
    {
        SceneManager.LoadScene("Level 1");
    }

    void NextLevel()
    {
        SceneManager.LoadScene("Level 1");
    }

    void ExitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
