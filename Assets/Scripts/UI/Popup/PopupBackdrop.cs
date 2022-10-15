using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/// <summary>
/// Popup background class. Used to check if user taps outside of popup.
/// </summary>
public class PopupBackdrop : MonoBehaviour, IPointerClickHandler
{
    OverlayManager overlayManager;

    public void SetParentUI(OverlayManager _overlayManager)
    {
        overlayManager = _overlayManager;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        overlayManager.OnBackdropTouch();
    }
}
