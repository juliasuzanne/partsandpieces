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
  private Color hoverColor;
  private Color prevColor;



  void Start()
  {
    selfSp = GetComponent<SpriteRenderer>();
    updateColor = new Color(244, 244, 244, 255);

  }

  public void ChangeColor(SpriteRenderer other)
  {
    selfSp.color = other.color;
    updateColor = other.color;
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    hit = other.GetComponent<IChangeColor>();
    if (sp)
    {
      if (sp.color == hoverColor)
      {
        sp.color = prevColor;
        hoverColor = new Color(1, 1, 1, 1);
      }
    }

    if (hit != null && !hit.changer)
    {
      sp = other.GetComponent<SpriteRenderer>();
      prevColor = new Color(sp.color.r, sp.color.g, sp.color.b, 1);
      hoverColor = new Color(selfSp.color.r, selfSp.color.g, selfSp.color.b, 1);
      sp.color = hoverColor;
      Debug.Log("hit" + hit);
    }
    else if (hit != null && hit.changer)
    {
      sp = other.GetComponent<SpriteRenderer>();

    }

  }

  void OnTriggerExit2D(Collider2D other)
  {
    if (sp != null && hit != null)
    {
      if (sp.color == hoverColor && !hit.changer)
      {
        sp.color = prevColor;
        hoverColor = new Color(1, 1, 1, 1);
      }
    }
    sp = null;



  }

  void OnMouseDown()
  {
    if (hit != null && sp != null)
    {
      if (!hit.changer)
      {
        hoverColor = new Color(1, 1, 1, 1);
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
