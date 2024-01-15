using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPuzzlePiecePos : MonoBehaviour
{
    private IPlaceable hit;
    [SerializeField] private int puzzleIdentifier;
    [SerializeField] private GameObject placedPiece;

    void OnTriggerEnter2D(Collider2D other)
    {
        hit = other.GetComponent<IPlaceable>();
        if (hit != null)
        {
            if (hit.puzzleID == puzzleIdentifier)
            {
                placedPiece.SetActive(true);
                Destroy(this.transform.parent.gameObject);
            }
        }

    }

}
