using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButtons : MonoBehaviour
{
    private bool mouse_over = false;



    public void OnPointerEnter(PointerEventData eventData)
    { mouse_over = true; }
    public void OnCursorExit(PointerEventData eventData)
    {
        mouse_over = false;
    }
}
