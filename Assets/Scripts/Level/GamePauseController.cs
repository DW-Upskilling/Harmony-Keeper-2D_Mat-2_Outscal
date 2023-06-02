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
        ResumeButton.onClick.AddListener(Resume);
        RestartButton.onClick.AddListener(RestartLevel);
        MainMenuButton.onClick.AddListener(ExitToMainMenu);
    }

    void Resume()
    {
        Debug.Log("Resume");
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
