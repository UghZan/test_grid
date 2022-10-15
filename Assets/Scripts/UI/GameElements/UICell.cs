using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/// <summary>
/// UI Cell class. Handles placement of squares and informs CellManager upon updating it's state.
/// </summary>
public class UICell : MonoBehaviour
{
    //Cell index in CellManager's cell arrays. Used to connect UI elements and field state.
    public int ID { get; private set; }

    //Controls whether user can take a square out of cell. True for pocket cells, False for field cells.
    public bool CanTakeOut;
    //Controls whether user can place a square in cell. True for all cells.
    public bool CanPutIn;
    //Controls whether cell is a part of game field and should notify CellManager of it's state changes.
    public bool FieldCell;

    [SerializeField] UISquare keptSquare;
    public bool Occupied => keptSquare;
    
    CellManager parent;
    public void InitCell(CellManager parentManager, int id)
    {
        parent = parentManager;
        ID = id;
    }

    public void PlaceSquare(UISquare square, bool shouldNotifyParent = true)
    {
        keptSquare = square;
        square.transform.SetParent(transform, false);
        square.transform.localPosition = Vector3.zero;

        if (FieldCell && shouldNotifyParent) parent.UpdateFieldState(ID);
    }

    public void RemoveSquare()
    {
        keptSquare = null;
    }

    public void Clear()
    {
        if (Occupied)
        {
            Destroy(keptSquare.gameObject);
            keptSquare = null;
        }
    }

}
