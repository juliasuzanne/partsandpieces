using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBackground : MonoBehaviour
{
    [SerializeField] float startY;
    [SerializeField] float endY;
    [SerializeField] float step;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(transform.position.x, startY);

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = new Vector2(transform.position.x, endY);
        transform.position = Vector2.MoveTowards(transform.position, newPos, step);
        if (transform.position.y == endY)
        {
            transform.position = new Vector2(transform.position.x, startY);
        }

    }
}
