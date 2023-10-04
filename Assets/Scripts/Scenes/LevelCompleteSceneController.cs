using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

using Outscal.UnityFundamentals.Mat2.Managers;

public class LevelCompleteSceneController : MonoBehaviour
{

    public Button restartButton, nextButton, mainMenuButton;
    public TextMeshProUGUI heading, score;

    private GameManager gameManager;

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

        gameManager = GameManager.Instance;

    }

    void Start()
    {

            if (gameManager.CurrentLevel >= 6)
            {
                nextButton.interactable = false;
            }

            if (heading != null)
            {
                heading.text = $"Level {gameManager.CurrentLevel} Complete";
            }

            if (score != null)
            {
                score.text = $"Completed: {Mathf.Round(gameManager.CompletionPercentage)}%";
            }

    }

    void RestartLevel()
    {
        gameManager.LoadScene("Level " + gameManager.CurrentLevel);
    }

    void NextLevel()
    {
        if ( gameManager.CurrentLevel < 6)
        {
            gameManager.CurrentLevel += 1;
            SceneManager.LoadScene("Level " + gameManager.CurrentLevel);
        }
        else
            SceneManager.LoadScene("MainMenu");
    }

    void ExitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
