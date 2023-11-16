using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
  private Inventory _inventory;
  private Vector3 _startingPos;
  private Transform _item;
  // Start is called before the first frame update
  void Start()
  {
    _inventory = GameObject.Find("Player").transform.GetComponent<Inventory>();

  }

  // Update is called once per frame
  void Update()
  {
    if (_item != null)
    {
      Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      mousePosition.z = 99f;
      _item.position = mousePosition;
    }

  }


  public void ChangeItem(Transform item, Vector3 startingPos)
  {
    _item = item;
    _startingPos = startingPos;

  }

  public void MakeItemNull()
  {
    _item.position = _startingPos;
    _item = null;
  }
}
