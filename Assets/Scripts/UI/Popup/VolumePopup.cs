using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Volume window class.
/// </summary>
public class VolumePopup : Popup
{
    [SerializeField] TextMeshProUGUI volumeLabel;
    [SerializeField] Slider volumeSlider;

    public override void OnOpen()
    {
        base.OnOpen();
        UpdateVolumeText();
        volumeSlider.value = SoundManager.GAME_VOLUME;
    }

    public override void OnClose()
    {
        base.OnClose();
        SoundManager.SaveVolume();
    }

    public void SetVolume()
    {
        SoundManager.GAME_VOLUME = volumeSlider.value;
        UpdateVolumeText();
    }

    void UpdateVolumeText()
    {
        volumeLabel.text = $"{(SoundManager.GAME_VOLUME*100).ToString("00")}%";
    }
}
