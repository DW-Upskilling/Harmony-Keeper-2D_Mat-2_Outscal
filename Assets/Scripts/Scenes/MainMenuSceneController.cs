using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuSceneController : MonoBehaviour
{

    public GameObject IntialContainer;
    public GameObject MenuContainer;
    public Button[] LevelButtons;

    private int InitialLaunch;

    void Awake()
    {
        if (IntialContainer == null)
            throw new System.Exception("intialIntialContainerText");

        InitialLaunch = PlayerPrefs.GetInt("InitialLaunch", 0);
        ToggleContainers();

    }

    void Start()
    {
        if (LevelButtons != null)
            foreach (Button button in LevelButtons)
            {
                ButtonController buttonController = button.GetComponent<ButtonController>();
                if (buttonController == null)
                    continue;

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

            }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && InitialLaunch == 0)
        {
            TextController textController = IntialContainer.GetComponentInChildren<TextController>();
            if (textController != null)
            {
                PlayerPrefs.SetInt("InitialLaunch", 1);
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


    }

    void LevelSceneLoader(string name)
    {
        SceneManager.LoadScene(name);
    }
}
