using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Message popup class.
/// </summary>
public class MessagePopup : Popup
{
    [SerializeField] TextMeshProUGUI messageText;
    
    public void SetMessage(string text)
    {
        messageText.text = text;
    }
}
