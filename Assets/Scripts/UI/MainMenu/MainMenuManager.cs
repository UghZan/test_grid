using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Main menu class.
/// </summary>
public class MainMenuManager : MonoBehaviour
{
    [SerializeField] Button startButton;

    //This method connects startButton onClick event to SceneChangeManager method. We need to do it in code because two components are on the different scenes.
    private void Start()
    {
        startButton.onClick.RemoveAllListeners();
        startButton.onClick.AddListener(SceneChangeManager.instance.SwitchToGameMenu);
    }
}
