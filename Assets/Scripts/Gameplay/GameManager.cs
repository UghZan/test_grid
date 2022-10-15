using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides interaction between managers in different scenes. In this case used as a way to restart the game.
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField] CellManager cellManager;
    [SerializeField] OverlayManager overlayManager;

    public void RestartGame()
    {
        if(cellManager == null)
            cellManager = FindObjectOfType<CellManager>();

        overlayManager.ClosePopup();
        cellManager.CreateGame();
    }
}
