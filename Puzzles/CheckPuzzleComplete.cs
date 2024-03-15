using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class CheckPuzzleComplete : MonoBehaviour
{
    [SerializeField] private bool[] correctPieces;
    [SerializeField] UnityEvent onTrigger;

    private bool correct = false;

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
            onTrigger.Invoke();
        }
    }
}


