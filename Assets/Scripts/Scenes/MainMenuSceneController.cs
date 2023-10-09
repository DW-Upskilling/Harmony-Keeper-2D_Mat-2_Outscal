using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Outscal.UnityFundamentals.Mat2.Managers;

public class MainMenuSceneController : MonoBehaviour
{

    public GameObject IntialContainer;
    public GameObject MenuContainer;
    public Button[] LevelButtons;

    private int InitialLaunch;

    private GameManager gameManager;

    void Start()
    {
        if (IntialContainer == null)
            throw new System.Exception("intialIntialContainerText");

        gameManager = GameManager.Instance;

        InitialLaunch = gameManager.InitialLaunch;
        ToggleContainers();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && InitialLaunch == 0)
        {
            TextController textController = IntialContainer.GetComponentInChildren<TextController>();
            if (textController != null)
            {
                InitialLaunch = 1;

                PlayerPrefs.SetInt("InitialLaunch", InitialLaunch);

                gameManager.InitialLaunch = InitialLaunch;
            }
            ToggleContainers();
        }
    }

    void ToggleContainers()
    {
        if (InitialLaunch == 0)
        {
            IntialContainer.SetActive(true);
            MenuContainer.SetActive(false);
        }
        else
        {
            IntialContainer.SetActive(false);
            MenuContainer.SetActive(true);
        }

        if (LevelButtons != null)
            foreach (Button button in LevelButtons)
            {
                ButtonController buttonController = button.GetComponent<ButtonController>();
                if (buttonController == null)
                {
                    button.enabled = false;
                    continue;
                }

                int buttonStatus = PlayerPrefs.GetInt(button.name, 0);
                if (buttonStatus == 0)
                    buttonController.ButtonStatus = ButtonStatus.Locked;
                else if (buttonStatus == 1)
                {
                    buttonController.ButtonStatus = ButtonStatus.Unlocked;
                    button.onClick.AddListener(() => LevelSceneLoader(button.name));
                }
                else if (buttonStatus == 2)
                {
                    buttonController.ButtonStatus = ButtonStatus.Active;
                    button.onClick.AddListener(() => LevelSceneLoader(button.name));
                }
                else if (buttonStatus == 3)
                {
                    buttonController.ButtonStatus = ButtonStatus.Done;
                    button.onClick.AddListener(() => LevelSceneLoader(button.name));
                }

            }
    }

    void LevelSceneLoader(string name)
    {

        gameManager.CurrentLevel = int.Parse(name);

        SceneManager.LoadScene("Level " + name);
    }
}
