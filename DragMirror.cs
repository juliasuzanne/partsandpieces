using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMirror : MonoBehaviour
{
  private Vector2 mousePosition;

  private float offsetX, offsetY;
  [SerializeField]
  private float zPos = 2f;

  void Start()
  {
    Debug.Log("STARTING MIRROR POS: " + transform.position);
    transform.position = new Vector3(transform.position.x, transform.position.y, zPos);

  }

  void Update()
  {
    Debug.Log("mousePosition");
    Debug.Log("CURRENT MIRROR POS: " + transform.position);

  }
  void OnMouseDown()
  {
    Debug.Log("MOUSE DOWN ON MIRROR");

  }

  private void OnMouseDrag()
  {
    mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    transform.position = new Vector3(mousePosition.x, mousePosition.y, zPos);

  }

  private void OnMouseUp()
  {

  }

}
