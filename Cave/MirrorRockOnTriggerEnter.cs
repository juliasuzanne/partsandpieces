using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MirrorRockOnTriggerEnter : ItemOnTriggerEnter
{
  protected int _count = 0;


  protected override void OnTriggerEnter2D(Collider2D other)
  {
    INameable hit = other.GetComponent<INameable>();
    if (hit != null)
    {
      other.GetComponent<ApplySavedColor>().ApplyNameOnly();
      description_object.SetActive(true);
      description_text.text = "Use " + Name + " with " + hit.Name;
      if (other.gameObject.tag == "Player")
      {
        _onPlayer = true;
      }

    }
    if (other.gameObject.name == "Tears")
    {
      Debug.Log("HIT TEAR");
      if (_count < 4)
      {
        description_object.SetActive(true);
        description_text.text = _count + "/3 rocks filled";
        _count += 1;
      }
      else
      {
        description_object.SetActive(false);
        ChangeSprite();
        Destroy(other.gameObject);
      }
    }


  }

}
