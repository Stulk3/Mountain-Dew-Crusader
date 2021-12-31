using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChange : MonoBehaviour
{
    public Texture2D DefaultCursor;
    public Texture2D OnClickCursor;
    public CursorMode cursorMode = CursorMode.Auto;
    void OnMouseEnter()
    {
        Cursor.SetCursor(DefaultCursor, Vector2.zero, cursorMode);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }

}
