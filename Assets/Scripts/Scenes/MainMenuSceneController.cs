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

    void Start()
    {
        if (IntialContainer == null)
            throw new System.Exception("intialIntialContainerText");

        Singleton singleton = Singleton.Instance;
        if (singleton == null)
            return;
        InitialLaunch = singleton.InitialLaunch;
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

                Singleton singleton = Singleton.Instance;
                if (singleton != null)
                    singleton.InitialLaunch = InitialLaunch;
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
        Singleton singleton = Singleton.Instance;
        if (singleton != null)
        {
            singleton.CurrentLevel = int.Parse(name);
        }

        SceneManager.LoadScene("Level " + name);
    }
}
