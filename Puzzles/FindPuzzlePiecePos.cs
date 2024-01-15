using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPuzzlePiecePos : MonoBehaviour
{
    private IPlaceable hit;
    [SerializeField] private int puzzleIdentifier;
    [SerializeField] private GameObject placedPiece;

    void Update()
    {
        if (hit != null)
        {
            Debug.Log("CheckingPlacement");
            CheckPlacement();
        }
    }

    void CheckPlacement()
    {
        if (hit.puzzleID == puzzleIdentifier && Mathf.Abs(this.transform.parent.rotation.z) < 0.1f)
        {
            placedPiece.SetActive(true);
            Destroy(this.transform.parent.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        hit = other.GetComponent<IPlaceable>();
    }

    void OnTriggerExit2D()
    {
        hit = null;
    }

}
