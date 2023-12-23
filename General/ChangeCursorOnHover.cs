using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCursorOnHover : MonoBehaviour
{
    [SerializeField] Texture2D cursorImage;
    [SerializeField] Texture2D defaultCursor;
    // Start is called before the first frame update
    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorImage, Vector2.zero, CursorMode.ForceSoftware);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
    }
}
