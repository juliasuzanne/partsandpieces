using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidePuzzlePiece : MonoBehaviour
{
    [SerializeField] private SlideEmptyPiece controlPiece;
    [SerializeField] private int correctNum;
    [SerializeField] private Vector2 correctPos;
    [SerializeField] private Vector2 scaledCorrectPos;

    void Start()
    {
        controlPiece = transform.parent.GetComponent<SlideEmptyPiece>();
        scaledCorrectPos = new Vector2(correctPos.x * controlPiece.transform.localScale.x, correctPos.y * controlPiece.transform.localScale.y);
    }

    void Update()
    {

    }

    void OnMouseDown()
    {
        controlPiece.CheckSpacesAround(transform);
    }

    public void CheckPosition()
    {
        if (scaledCorrectPos.x + transform.parent.position.x == transform.position.x && scaledCorrectPos.y + transform.parent.position.y == transform.position.y)
        {
            controlPiece.AdjustTrue(correctNum);
        }
        else
        {
            Debug.Log(transform.position.x);
            controlPiece.AdjustFalse(correctNum);
        }
    }


}
