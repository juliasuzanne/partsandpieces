using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustSortingLayer : MonoBehaviour
{
    [SerializeField] SpriteRenderer sp;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private int inFrontOrderNum;
    [SerializeField] private int inBackOrderNum;
    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > playerTransform.position.y)
        {
            sp.sortingOrder = inBackOrderNum;

        }
        else
        {
            sp.sortingOrder = inFrontOrderNum;
        }


    }
}
