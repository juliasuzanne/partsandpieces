using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseNoChangeCursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        transform.position = mousePos2D;
    }
}
