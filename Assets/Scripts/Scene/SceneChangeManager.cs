using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controls scene changes. Implements singleton to allow access indifferent of scene.
/// </summary>
public class SceneChangeManager : MonoBehaviour
{
    public static SceneChangeManager instance { get; private set; }

    [SerializeField] string MainMenuSceneName;
    [SerializeField] string GameFieldSceneName;
    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        instance = this;
    }

    public void SwitchToGameMenu()
    {
        SceneManager.UnloadSceneAsync(MainMenuSceneName);
        SceneManager.LoadScene(GameFieldSceneName, LoadSceneMode.Additive);
    }
}
