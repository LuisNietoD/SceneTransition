using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCursor : MonoBehaviour
{

    
    GameCtrl cursor;
    public Vector2 pointerOffset;
    public void ChangeCursorToPointer()
    {

        Cursor.SetCursor(cursor.crosshairOnClick, pointerOffset, CursorMode.ForceSoftware); //doesn't work
    }

    public void ChangeCursorBack()
    {
        pointerOffset = new Vector2(0.1248604f, 0.9347787f);
        Cursor.SetCursor(cursor.crosshair, cursor.cursorOffset, CursorMode.ForceSoftware);

    }
}
