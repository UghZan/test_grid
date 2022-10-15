using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// UI Square class. A draggable square element.
/// </summary>
public class UISquare : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public UICell CellParent { get; private set; }

    bool isDragged;
    UICell lastParent;
    Canvas parentCanvas;

    void Start()
    {
        parentCanvas = GetComponentInParent<Canvas>();
        if(CellParent == null)
        {
            CellParent = GetComponentInParent<UICell>();
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (CellParent == null)
            return;
        if (!CellParent.CanTakeOut)
            return;

        isDragged = true;
        lastParent = CellParent;
        lastParent.RemoveSquare();
        transform.SetParent(parentCanvas.transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(isDragged)
            transform.localPosition += new Vector3(eventData.delta.x, eventData.delta.y, 0) / transform.lossyScale.x;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!isDragged)
            return;

        //check for objects underneath the cursor/finger on drop
        List<RaycastResult> objectsUnder = new List<RaycastResult>();
        parentCanvas.GetComponent<GraphicRaycaster>().Raycast(eventData, objectsUnder);
        foreach(var obj in objectsUnder)
        {
            //if there's a cell somewhere underneath, place it here
            if(obj.gameObject.TryGetComponent(out UICell cell))
            {
                if (cell.Occupied) continue;

                CellParent = cell;
                CellParent.PlaceSquare(this);

                isDragged = false;
                return;
            }
        }
        //if we drop it outside of a cell, bring the square back to it's original cell
        lastParent.PlaceSquare(this);
        isDragged = false;
    }
}
