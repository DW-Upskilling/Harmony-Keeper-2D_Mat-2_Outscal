using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelCompleteSceneController : MonoBehaviour
{

    public Button restartButton, nextButton, mainMenuButton;

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
