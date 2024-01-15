using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidePuzzlePiece : MonoBehaviour
{
    [SerializeField] private Vector2 oneone = new Vector2(0, 0);
    [SerializeField] private Vector2 onetwo = new Vector2(1, 0);
    [SerializeField] private Vector2 onethree = new Vector2(2, 0);
    [SerializeField] private Vector2 twoone = new Vector2(0, -1);
    [SerializeField] private Vector2 twotwo = new Vector2(1, -1);
    [SerializeField] private Vector2 twothree = new Vector2(2, -1);
    [SerializeField] private Vector2 threeone = new Vector2(0, -2);
    [SerializeField] private Vector2 threetwo = new Vector2(1, -2);
    [SerializeField] private Vector2 emptyPos = new Vector2(2, -2);


    // Start is called before the first frame update
    void Start()
    {
        emptyPos = new Vector2(2, -2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        CheckSpacesAround();
    }

    void CheckSpacesAround()
    {
        if (transform.position.x + 1 == emptyPos.x)
        {
            Debug.Log(transform.position.x + 1);
        }
    }
}
