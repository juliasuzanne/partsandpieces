using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseNoChangeCursor : MonoBehaviour

{
    [SerializeField] private bool allowMove = true;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (allowMove == true)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            transform.position = mousePos2D;
        }
        else
        {
            Vector3 mousePos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            transform.position = mousePos2D;
        }

    }

    public void AllowMove()
    {
        allowMove = true;

    }
    public void DontAllowMove()
    {
        allowMove = false;

    }
}
