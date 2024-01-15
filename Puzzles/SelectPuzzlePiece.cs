using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPuzzlePiece : MonoBehaviour
{
    private RotatePuzzlePiece puzzleScript;


    void Start()
    {
        puzzleScript = transform.parent.GetComponent<RotatePuzzlePiece>();
    }


    private void OnMouseDown()
    {
        puzzleScript.ChangeCurrentPiece(transform);
    }
}
