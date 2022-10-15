using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base popup class.
/// </summary>
public abstract class Popup : MonoBehaviour
{
    public bool canBeClosedByTouchingOutside = false;

    public virtual void OnOpen()
    {
        gameObject.SetActive(true);
    }

    public virtual void OnClose()
    {
        gameObject.SetActive(false);
    }
}
