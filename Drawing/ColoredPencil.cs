using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColoredPencil : MonoBehaviour
{
  private IChangeColor hit;
  private SpriteRenderer sp;
  private Color updateColor;

  void Start()
  {

  }

  void OnTriggerEnter2D(Collider2D other)
  {
    sp = other.GetComponent<SpriteRenderer>();
    hit = other.GetComponent<IChangeColor>();


  }

  void OnTriggerExit2D(Collider2D other)
  {

  }

  void OnMouseDown()
  {
    sp.color = new Color(0, 0, 0);
  }



}
