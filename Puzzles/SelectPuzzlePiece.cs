using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPuzzlePiece : MonoBehaviour, IPlaceable
{
    private RotatePuzzlePiece puzzleScript;
    [SerializeField] private int puzzleIdentifier;
    public int puzzleID
    {
        get
        {
            return puzzleIdentifier;
        }
    }

    void Start()
    {
        puzzleScript = transform.parent.GetComponent<RotatePuzzlePiece>();
    }
    public int GetPuzzleID()
    {
        return puzzleID;
    }

    private void OnMouseDown()
    {
        puzzleScript.ChangeCurrentPiece(transform);
    }
}
