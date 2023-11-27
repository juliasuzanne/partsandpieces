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

      if (other.gameObject.tag == "Player")
      {
        other.GetComponent<ApplySavedColor>().ApplyNameOnly();
        description_object.SetActive(true);
        description_text.text = "Use " + Name + " with " + hit.Name;
        _onPlayer = true;
      }
      else if (other.gameObject.name == "RockFaces")
      {
        description_object.SetActive(true);
        description_text.text = "Use " + Name + " with " + hit.Name;
        _onRocks = true;

      }

      else
      {
        description_object.SetActive(true);
        description_text.text = "Use " + Name + " with " + hit.Name;
      }


    }
    if (other.gameObject.name == "Tear")
    {
      description_object.SetActive(true);
      Debug.Log("HIT TEAR");
      if (_count < 3)
      {
        other.GetComponent<Animator>().SetTrigger("Splash");
        other.GetComponent<FallingObject>().Splashed();
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

  protected override void OnTriggerExit2D(Collider2D collision)
  {
    if (collision.gameObject.name != "Tear")
    {
      description_object.SetActive(false);
      description_text.text = "";
    }

    _onRocks = false;
    _onPlayer = false;


  }



}