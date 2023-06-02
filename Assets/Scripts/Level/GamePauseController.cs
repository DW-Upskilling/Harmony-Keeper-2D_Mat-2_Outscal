using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePauseController : MonoBehaviour
{
    public Button ResumeButton, RestartButton, MainMenuButton;

    void Awake()
    {
        if (ResumeButton == null)
            throw new System.Exception("ResumeButton");
        ResumeButton.onClick.AddListener(Resume);

        if (RestartButton == null)
            throw new System.Exception("RestartButton");
        RestartButton.onClick.AddListener(RestartLevel);

        if (MainMenuButton == null)
            throw new System.Exception("MainMenuButton");
        MainMenuButton.onClick.AddListener(ExitToMainMenu);
    }

    void Resume()
    {
        LevelSceneController levelSceneController = gameObject.GetComponentInParent<LevelSceneController>();
        if (levelSceneController != null)
            levelSceneController.TogglePauseScreen();
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void ExitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
