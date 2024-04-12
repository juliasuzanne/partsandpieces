using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColoredPencil : MonoBehaviour
{
  private IChangeColor hit;
  private SpriteRenderer sp;
  private SpriteRenderer selfSp;
  private Color updateColor;

  void Start()
  {
    selfSp = GetComponent<SpriteRenderer>();

  }

  public void ChangeColor(SpriteRenderer other)
  {
    selfSp.color = other.color;
    updateColor = other.color;
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    sp = other.GetComponent<SpriteRenderer>();
    hit = other.GetComponent<IChangeColor>();
    Debug.Log("hit" + hit);
  }

  void OnTriggerExit2D(Collider2D other)
  {
    hit = null;

  }

  void OnMouseDown()
  {
    if (hit != null)
    {
      if (!hit.changer)
      {
        sp.color = updateColor;
        hit.UpdateColor(sp.color.r, sp.color.g, sp.color.b);
      }
      else if (hit.changer)
      {
        selfSp.color = sp.color;
        updateColor = sp.color;
      }

    }
  }



}
