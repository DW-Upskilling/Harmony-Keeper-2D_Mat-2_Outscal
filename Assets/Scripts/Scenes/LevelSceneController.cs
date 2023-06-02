using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSceneController : MonoBehaviour
{

    public GameObject PauseScreen;
    public GameObject[] GameObjectsToPause, GameObjectsOnPauseScreen;

    void Awake()
    {
        if (GameObjectsToPause == null)
            throw new System.Exception("GameObjectsToPause");
        if (GameObjectsOnPauseScreen == null)
            throw new System.Exception("GameObjectsToPause");
        if (PauseScreen == null && PauseScreen.GetComponent<GamePauseController>() != null)
            throw new System.Exception("PauseScreen");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseScreen();
        }
    }

    public void TogglePauseScreen()
    {
        if (PauseScreen.activeSelf == true)
        {
            PauseScreen.SetActive(false);
            foreach (GameObject current in GameObjectsOnPauseScreen)
            {
                current.SetActive(false);
            }
            foreach (GameObject current in GameObjectsToPause)
            {
                current.SetActive(true);
            }

        }
        else
        {
            PauseScreen.SetActive(true);
            foreach (GameObject current in GameObjectsOnPauseScreen)
            {
                current.SetActive(true);
            }
            foreach (GameObject current in GameObjectsToPause)
            {
                current.SetActive(false);
            }

        }
    }
}
