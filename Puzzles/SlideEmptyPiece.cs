using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideEmptyPiece : MonoBehaviour
{
    [SerializeField] private Vector2 emptyPos = new Vector2(2, -2);
    [SerializeField] private bool[] correctPieces;
    private bool correct = false;
    void Start()
    {
        emptyPos = new Vector2(transform.position.x, transform.position.y);

    }
    public void CheckSpacesAround(Transform currentPiece)
    {
        if (Mathf.Abs(currentPiece.position.x - emptyPos.x) <= 1 * transform.localScale.x && Mathf.Abs(currentPiece.position.y - emptyPos.y) == 0 || Mathf.Abs(currentPiece.position.x - emptyPos.x) == 0 && Mathf.Abs(currentPiece.position.y - emptyPos.y) <= 1 * transform.localScale.y)
        {
            Vector2 newPos = currentPiece.position;
            currentPiece.position = emptyPos;
            emptyPos = newPos;
            currentPiece.GetComponent<SlidePuzzlePiece>().CheckPosition();
        }

    }

    public void AdjustTrue(int num)
    {
        correctPieces[num] = true;
        CheckSolution();
    }
    public void AdjustFalse(int num)
    {
        correctPieces[num] = false;
        CheckSolution();
    }

    public void CheckSolution()
    {
        correct = true;
        for (int i = 0; i < correctPieces.Length; i++)
        {
            if (correctPieces[i] == false)
            {
                correct = false;
            }
        }
        if (correct == true)
        {
            Debug.Log("CORRECT!");
        }
    }
}
