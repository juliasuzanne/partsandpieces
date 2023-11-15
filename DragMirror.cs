using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMirror : MonoBehaviour
{
  private Vector2 mousePosition;
  private bool mouseButtonDown;

  private float offsetX, offsetY;
  [SerializeField]
  private float zPos = 2f;
  private float maxX, minX, maxY, minY;


  void Start()
  {
    Debug.Log("STARTING MIRROR POS: " + transform.position);
    transform.position = new Vector3(transform.position.x, transform.position.y, zPos);
    maxX = transform.position.x + 12.05f;
    maxY = transform.position.y + 0.5f;
    minX = transform.position.x - 12.05f;
    minY = transform.position.y - 0.5f;

  }

  void Update()
  {
    Debug.Log("mousePosition");
    Debug.Log("CURRENT MIRROR POS: " + transform.position);

  }
  void OnMouseDown()
  {
    Debug.Log("MOUSE DOWN ON MIRROR");
    mouseButtonDown = true;
    offsetX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
    offsetY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;


  }

  private void OnMouseDrag()
  {
    if (transform.position.x > maxX)
    {
      transform.position = new Vector3(maxX - 0.1f, transform.position.y, transform.position.z);
      offsetX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - maxX;
    }
    else if (transform.position.x < minX)
    {
      transform.position = new Vector3(minX + 0.1f, transform.position.y, transform.position.z);
      offsetX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - minX;
    }
    else if (transform.position.y > maxY)
    {
      transform.position = new Vector3(transform.position.x, maxY - 0.1f, transform.position.z);
      offsetY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - maxY;

    }
    else if (transform.position.y < minY)
    {
      transform.position = new Vector3(transform.position.x, minY + 0.1f, transform.position.z);
      offsetY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - minY;
    }
    else
    {
      if (mouseButtonDown == true)
      {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x - offsetX, mousePosition.y - offsetY, zPos);
      }

    }

  }

  private void OnMouseUp()
  {
    mouseButtonDown = false;
  }

}
