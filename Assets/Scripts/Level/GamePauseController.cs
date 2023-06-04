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
        // Assign click event listeners to the buttons

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
        // Resume the game by toggling the pause screen

        LevelSceneController levelSceneController = gameObject.GetComponentInParent<LevelSceneController>();

        if (levelSceneController != null)
            levelSceneController.TogglePauseScreen();
    }

    void RestartLevel()
    {
        // Reload the current scene to restart the level

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void ExitToMainMenu()
    {
        // Load the main menu scene

        SceneManager.LoadScene("MainMenu");
    }
}
