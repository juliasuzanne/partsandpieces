using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideEmptyPiece : MonoBehaviour
{
    private Vector2 emptyPos;
    void Start()
    {
        emptyPos = new Vector2(2, -2);

    }
    public void CheckSpacesAround(Transform currentPiece)
    {
        if (Mathf.Abs(currentPiece.position.x - emptyPos.x) <= 1 && Mathf.Abs(currentPiece.position.y - emptyPos.y) == 0 || Mathf.Abs(currentPiece.position.x - emptyPos.x) == 0 && Mathf.Abs(currentPiece.position.y - emptyPos.y) <= 1)
        {
            Vector2 newPos = currentPiece.position;
            currentPiece.position = emptyPos;
            emptyPos = newPos;
        }

    }
}
