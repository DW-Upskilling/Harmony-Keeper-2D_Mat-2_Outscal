using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Outscal.UnityFundamentals.Mat2.Managers.Audio;

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
            case ButtonStatus.Inactive:
                gameObject.SetActive(false);
                break;
            case ButtonStatus.Active:
                gameObject.SetActive(true);
                buttonImage.color = Color.cyan;
                break;
            case ButtonStatus.Locked:
                gameObject.SetActive(true);
                button.interactable = false;
                buttonImage.color = Color.grey;
                break;
            case ButtonStatus.Unlocked:
                gameObject.SetActive(true);
                buttonImage.color = Color.green;
                break;
            case ButtonStatus.Done:
                gameObject.SetActive(true);
                buttonImage.color = Color.blue;
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
