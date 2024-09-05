using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustSortingLayer : MonoBehaviour
{
    [SerializeField] SpriteRenderer sp;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private int inFrontOrderNum;
    [SerializeField] private int inBackOrderNum;
    [SerializeField] private float offsetY;
    // Start is called before the first frame update
    void Start()
    {
        if (sp == null)
        {
            sp = GetComponent<SpriteRenderer>();
        }
        if (playerTransform == null)
        {
            playerTransform = GameObject.FindWithTag("Player").transform;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y + offsetY > playerTransform.position.y)
        {
            sp.sortingOrder = inBackOrderNum;

        }
        else
        {
            sp.sortingOrder = inFrontOrderNum;
        }


    }
}
