using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePuzzlePiece : MonoBehaviour
{
    private float xRotate;
    private float yRotate;
    private IPlaceable hit;
    [SerializeField] private Transform currentPiece;
    [SerializeField] private float _rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void ChangeCurrentPiece(Transform newTransform)
    {
        currentPiece = newTransform;
    }

    // Update is called once per frame
    void Update()
    {
        xRotate = Input.GetAxis("Horizontal");
        yRotate = Input.GetAxis("Vertical");
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        currentPiece.position = mousePos2D;
        currentPiece.Rotate(0f, 0f, _rotateSpeed * (xRotate), Space.Self);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        hit = other.GetComponent<IPlaceable>();
        if (hit != null)
        {
            if (hit.puzzleID == currentPiece.GetComponent<SelectPuzzlePiece>().puzzleID)
            {

            }
        }

    }


}
