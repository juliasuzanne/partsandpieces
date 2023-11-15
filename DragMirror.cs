using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMirror : MonoBehaviour
{
  private Vector2 mousePosition;

  private float offsetX, offsetY;


  void Update()
  {
    Debug.Log("mousePosition");

  }
  void OnMouseDown()
  {
    mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    Debug.Log("MOUSE DOWN ON MIRROR");

  }

  private void OnMouseDrag()
  {
    Debug.Log("MOUSE DRAG ON MIRROR");

    transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);

  }

  private void OnMouseUp()
  {

  }

}
