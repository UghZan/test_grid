using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls music.
/// </summary>
public class SoundManager : MonoBehaviour
{
    public static float GAME_VOLUME = 0.5f;
    AudioSource musicSource;

    private void Start()
    {
        musicSource = GetComponent<AudioSource>();
        GAME_VOLUME = PlayerPrefs.GetFloat("Volume", 0.5f);
    }

    private void Update()
    {
        musicSource.volume = GAME_VOLUME;
    }

    public static void SaveVolume()
    {
        PlayerPrefs.SetFloat("Volume", GAME_VOLUME);
        PlayerPrefs.Save();
    }
}
