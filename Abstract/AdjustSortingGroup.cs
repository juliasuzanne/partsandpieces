using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class AdjustSortingGroup : MonoBehaviour
{
    [SerializeField] SortingGroup sp;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private int inFrontOrderNum;
    [SerializeField] private int inBackOrderNum;
    [SerializeField] private float offsetY;
    // Start is called before the first frame update
    void Start()
    {
        if (sp == null)
        {
            sp = GetComponent<SortingGroup>();
        }
        if (playerTransform == null)
        {
            playerTransform = GameObject.FindWithTag("Player").transform;
        }

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(sp.name + " " + sp.sortingOrder);
        if (transform.position.y + offsetY > playerTransform.position.y)
        {
            Debug.Log(sp.name + "putting back");
            sp.sortingOrder = inBackOrderNum;

        }
        else
        {
            sp.sortingOrder = inFrontOrderNum;
        }


    }
}
