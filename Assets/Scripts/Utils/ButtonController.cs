using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    private Button button;
    private Image buttonImage;
    private ButtonStatus buttonStatus;
    public ButtonStatus ButtonStatus
    {
        set
        {
            setButtonStatus(value);
        }
        get { return buttonStatus; }
    }
    void Awake()
    {
        button = gameObject.GetComponent<Button>();
        if (button == null)
            throw new System.Exception("button");

        button.onClick.AddListener(buttonClickListener);

        buttonImage = gameObject.GetComponent<Image>();
        if (buttonImage == null)
            buttonImage = gameObject.AddComponent<Image>();
    }

    void setButtonStatus(ButtonStatus _buttonStatus)
    {
        if (buttonImage == null)
            return;

        switch (_buttonStatus)
        {
            case ButtonStatus.Active:
                buttonImage.color = Color.cyan;
                break;
            case ButtonStatus.Inactive:
                gameObject.SetActive(false);
                break;
            case ButtonStatus.Unlocked:
                buttonImage.color = Color.green;
                break;
            case ButtonStatus.Locked:
                buttonImage.color = Color.grey;
                button.interactable = false;
                break;
        }
    }

    void buttonClickListener()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.Play("Click");
        }
    }
}
