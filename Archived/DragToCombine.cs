using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragToCombine : MonoBehaviour
{
    private Vector2 mousePosition;

    private float offsetX, offsetY;
    public static bool mouseButtonReleased;

    [SerializeField]
    private float maxX, minX, maxY, minY;



    private void OnMouseDown()
    {
        Debug.Log("STARTING MIRROR POS: " + transform.position);
        maxX = transform.position.x + 2.5f;
        maxY = transform.position.y + 2.25f;
        minX = transform.position.x - 2.5f;
        minY = transform.position.y - 2.25f;

        mouseButtonReleased = false;
        offsetX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        offsetY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
    }

    private void OnMouseDrag()
    {
        // Debug.Log("CURRENT MIRROR POS: " + transform.position);
        if (transform.position.x > maxX || transform.position.x < minX || transform.position.y > maxY || transform.position.y < minY)
        {
            mouseButtonReleased = true;
            transform.position = new Vector3(maxX - 2.5f, maxY - 2.25f, transform.position.z);
        }
        else
        {
            if (mouseButtonReleased == false)
            {
                mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = new Vector3(mousePosition.x - offsetX, mousePosition.y - offsetY, transform.position.z);
            }

        }


    }

    private void OnMouseUp()
    {
        mouseButtonReleased = true;

    }

    // private void OnTriggerStay2D(Collider2D collision)
    // {
    //     string thisGameobjectName;
    //     string collisionGameobjectName;

    //     thisGameobjectName = gameObject.name.Substring(0, name.IndexOf("_"));
    //     collisionGameobjectName = collision.gameObject.name.Substring(0, name.IndexOf("_"));

    //     if (mouseButtonReleased && thisGameobjectName == "string" && thisGameobjectName == collisionGameobjectName)
    //     {
    //         Instantiate(Resources.Load("yarn_drag"), transform.position, Quaternion.identity);
    //         mouseButtonReleased = false;
    //         Destroy(collision.gameObject);
    //         Destroy(gameObject);
    //     }
    //     else if (mouseButtonReleased && thisGameobjectName == "leaf" && collisionGameobjectName == "yarn")
    //     {
    //         Instantiate(Resources.Load("string_drag"), transform.position, Quaternion.identity);
    //         mouseButtonReleased = false;
    //         Destroy(collision.gameObject);
    //         Destroy(gameObject);
    //     }
    // }
}
