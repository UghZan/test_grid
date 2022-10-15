using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls overlay windows such as volume window and game over/win screens
/// </summary>
public class OverlayManager : MonoBehaviour
{
    [Header("Main Settings")]
    [SerializeField] PopupBackdrop backdrop;
    [Header("Popups")]
    [SerializeField] VolumePopup volumePopup;
    [SerializeField] MessagePopup messagePopup;

    Popup currentPopup;
    bool isPopupOnScreen;

    private void Start()
    {
        backdrop.SetParentUI(this);
    }

    void OnPopupOpen()
    {
        backdrop.gameObject.SetActive(true);
        isPopupOnScreen = true;
    }

    void OnPopupClose()
    {
        backdrop.gameObject.SetActive(false);
        isPopupOnScreen = false;
    }

    void CreateMessagePopup(string message)
    {
        if (isPopupOnScreen) return;

        OnPopupOpen();
        messagePopup.OnOpen();
        messagePopup.SetMessage(message);

        currentPopup = messagePopup;
    }

    public void ShowGameoverPopup()
    {
        CreateMessagePopup("GAME OVER");
    }

    public void ShowWinPopup()
    {
        CreateMessagePopup("YOU WIN");
    }

    public void OpenVolumeMenu()
    {
        if (isPopupOnScreen) return;

        OnPopupOpen();
        volumePopup.OnOpen();

        currentPopup = volumePopup;
    }

    public void OnBackdropTouch()
    {
        if (!currentPopup.canBeClosedByTouchingOutside) return;
        ClosePopup();
    }

    public void ClosePopup()
    {
        currentPopup.OnClose();
        OnPopupClose();
    }
}
