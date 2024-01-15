using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidePuzzlePiece : MonoBehaviour
{
    [SerializeField] private SlideEmptyPiece controlPiece;
    [SerializeField] private int correctNum;
    [SerializeField] private Vector2 correctPos;

    void Start()
    {
        controlPiece = transform.parent.GetComponent<SlideEmptyPiece>();
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
        if (correctPos.x == transform.position.x && correctPos.y == transform.position.y)
        {
            controlPiece.AdjustTrue(correctNum);
        }
        else
        {
            controlPiece.AdjustFalse(correctNum);
        }
    }


}
