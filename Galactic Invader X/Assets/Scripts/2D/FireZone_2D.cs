using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FireZone_2D : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update
    private bool touched,canFire;
    private int pointerID;

    void Awake()
    {
        touched = false;
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (!touched)
        {
            touched = true;
            pointerID = data.pointerId;
            canFire = true;
        }
    }
    public void OnPointerUp(PointerEventData data)
    {
        if (data.pointerId == pointerID)
        {
            touched = false;
            canFire = false;
        }
    }
    public bool CanFire()
    {
        return canFire;
    }
}
