using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AllowDraw : MonoBehaviour
{
    [SerializeField] private SpriteMask spriteMask;
    [SerializeField] private float alphaCutValue;
    [SerializeField] private UnityEvent onComplete;
    // Start is called before the first frame update
    void Start()
    {
        spriteMask.alphaCutoff = 1;
    }



    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDrag()
    {
        // if (alphaCutValue == 0)
        // {
        //     spriteMask.alphaCutoff = spriteMask.alphaCutoff + 0.1f;

        // }
        // else
        // {
        spriteMask.alphaCutoff = spriteMask.alphaCutoff - alphaCutValue;

        if (spriteMask.alphaCutoff == 0)
        {
            onComplete.Invoke();

        }

        // }
    }
}
