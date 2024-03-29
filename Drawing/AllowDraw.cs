using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowDraw : MonoBehaviour
{
    [SerializeField] private SpriteMask spriteMask;
    [SerializeField] private float alphaCutValue;
    // Start is called before the first frame update
    void Start()
    {
        spriteMask.alphaCutoff = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDrag()
    {
        if (alphaCutValue == 0)
        {
            spriteMask.alphaCutoff = spriteMask.alphaCutoff + 0.1f;

        }
        else
        {
            spriteMask.alphaCutoff = spriteMask.alphaCutoff + alphaCutValue;

        }
    }
}
