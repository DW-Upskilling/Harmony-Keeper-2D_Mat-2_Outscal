using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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

        foreach (Button button in LevelButtons)
        {
            ButtonController buttonController = button.GetComponent<ButtonController>();
            if (buttonController == null)
                continue;

            int buttonStatus = PlayerPrefs.GetInt(button.name, 0);
            if (buttonStatus == 0)
                buttonController.ButtonStatus = ButtonStatus.Locked;
            else if (buttonStatus == 1)
                buttonController.ButtonStatus = ButtonStatus.Unlocked;
            else if (buttonStatus == 2)
                buttonController.ButtonStatus = ButtonStatus.Active;

        }

        InitialLaunch = PlayerPrefs.GetInt("InitialLaunch", 1);
        if (InitialLaunch != 1)
        {
            ToggleContainers();
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && InitialLaunch == 1)
        {
            TextController textController = IntialContainer.GetComponentInChildren<TextController>();
            if (textController != null)
            {
                ToggleContainers();
            }
        }
    }

    void ToggleContainers()
    {
        IntialContainer.SetActive(false);
        MenuContainer.SetActive(true);

        // PlayerPrefs.SetInt("InitialLaunch", 0);
    }
}
