using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPos : MonoBehaviour
{
    [SerializeField] float yMax, yMin, xMin, xMax;
    [SerializeField] SpriteRenderer sp;
    [SerializeField] CheckPuzzleComplete _checkPuzzle;
    [SerializeField] int puzzleNum;
    void Update()
    {
        if (transform.position.x >= xMax || transform.position.y >= yMax || transform.position.x <= xMin || transform.position.y <= yMin)
        {
            _checkPuzzle.AdjustTrue(puzzleNum);
        }
    }

    public void ChangeOpacity(float alphaValue)
    {
        sp.color = new Color(255f, 255f, 255f, alphaValue);
    }
}
