using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class CursorChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
       // CursorScript.SetOnClickCursor();
    }
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        //CursorScript.SetDefaultCursor();

    }
}
