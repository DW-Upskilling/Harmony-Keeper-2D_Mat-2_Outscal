using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public GameObject platforms, animals;

    public void GoalReached()
    {
        SceneManager.LoadScene("LevelComplete");
    }

}
