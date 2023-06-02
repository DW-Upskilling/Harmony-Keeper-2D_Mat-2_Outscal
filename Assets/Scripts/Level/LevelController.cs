using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    void Awake()
    {
        StartCoroutine(LoadLevelComplete());
    }

    IEnumerator LoadLevelComplete()
    {
        yield return new WaitForSeconds(10);

        SceneManager.LoadScene("LevelComplete");
    }

}
