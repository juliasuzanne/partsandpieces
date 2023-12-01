using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
  private Inventory _inventory;
  [SerializeField]
  private GameObject _gameObject;

  // Start is called before the first frame update
  void Start()
  {
    _inventory = GameObject.Find("Player").transform.GetComponent<Inventory>();
  }

  // Update is called once per frame
  void Update()
  {

  }

  void OnMouseDown()
  {
    _inventory.AddItemToInventory(_gameObject);
    Destroy(this.gameObject);
  }
}



