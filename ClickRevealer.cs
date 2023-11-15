using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickRevealer : MonoBehaviour
{

  //The click mananger returns the object that was clicked and the distance between the player and that object.

  private Transform t;
  private Transform player;
  public GameObject clicked;


  void Awake()
  {
    player = GameObject.FindGameObjectWithTag("Player").transform;


  }

  public void MakeNull()
  {
    clicked = null;
  }


  void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

      RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
      if (hit.collider != null)
      {
        clicked = hit.collider.gameObject;
        Debug.Log("CLICKED " + clicked.transform.name);
        t = hit.collider.gameObject.transform;
      }
    }
  }



  public float Distance()
  {
    return Vector3.Distance(t.position, player.position);
  }
}