using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuSceneController : MonoBehaviour
{

    public TextMeshProUGUI intialText;

    void Awake()
    {
        if (intialText == null)
            throw new System.Exception("intialText");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TextController textController = intialText.GetComponent<TextController>();
            if (textController != null)
            {
                Destroy(textController);
            }
        }
    }
}
