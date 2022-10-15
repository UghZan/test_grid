using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls cell field, creates starting squares, controls cell state updates
/// </summary>
public class CellManager : MonoBehaviour
{
    [Header("Field Settings")]

    [Tooltip("All the field cells in the scene")]
    [SerializeField] UICell[] fieldCells;

    [Tooltip("Which field cells should be filled at the beginning/restart")]
    [SerializeField] bool[] startingState = new bool[9];

    [Tooltip("Which field cells should be filled for the game to be considered as a win")]
    [SerializeField] bool[] winState = new bool[9];

    [Header("Pocket Settings")]

    [Tooltip("All the pocket cells in the scene")]
    [SerializeField] UICell[] pocketCells;

    [Tooltip("Which pocket cells should be filled at the beginning/restart")]
    [SerializeField] bool[] startingPocketState = new bool[2];

    [Header("Misc Settings")]

    [Tooltip("Square prefab")]
    [SerializeField] GameObject square;

    //current field state
    bool[] CellState = new bool[9];
    OverlayManager overlayManager;

    void Start()
    {
        overlayManager = FindObjectOfType<OverlayManager>();

        InitCells();
        CreateGame();
    }

    /// <summary>
    /// Initiates cells on the scene: gives them an ID and updates their settings in accordance with their role
    /// </summary>
    void InitCells()
    {
        int idx = 0;
        foreach(UICell cell in fieldCells)
        {
            cell.InitCell(this, idx++);
            cell.FieldCell = true;
            cell.CanTakeOut = false;
            cell.CanPutIn = true;
        }
        idx = 0;
        foreach(UICell cell in pocketCells)
        {
            cell.InitCell(this, idx++);
            cell.FieldCell = false;
            cell.CanTakeOut = true;
            cell.CanPutIn = true;
        }
    }

    /// <summary>
    /// Resets existing game state to a starting state. Called on the first launch and on restart button press.
    /// </summary>
    public void CreateGame()
    {
        foreach (UICell cell in fieldCells)
        {
            cell.Clear();
            if (startingState[cell.ID])
            {
                GameObject _square = Instantiate(square, cell.transform);
                cell.PlaceSquare(_square.GetComponent<UISquare>(), false);
                CellState[cell.ID] = true;
            }
            else
                CellState[cell.ID] = false;
        }

        foreach (UICell cell in pocketCells)
        {
            cell.Clear();
            if (startingPocketState[cell.ID])
            {
                GameObject _square = Instantiate(square, cell.transform);
                cell.PlaceSquare(_square.GetComponent<UISquare>(), false);
            }
        }
    }

    /// <summary>
    /// Updates field state. Called from field cells when a square is dropped into them. 
    /// </summary>
    public void UpdateFieldState(int cellID)
    {
        CellState[cellID] = true;

        for (int i = 0; i < 9; i++)
        {
            if (CellState[i] != winState[i])
            {
                overlayManager.ShowGameoverPopup();
                return;
            }
        }
        overlayManager.ShowWinPopup();
    }
}
