using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
  [SerializeField] private Sprite OpenInventory;
  [SerializeField] private Sprite CloseInventory;
  [SerializeField] private Inventory _inventory;
  private UIManager _uiManager;
  private SpriteRenderer _sp;
  [SerializeField] bool usingPockets = true;


  void Start()
  {
    _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    _sp = transform.GetComponent<SpriteRenderer>();
    _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();

  }

  void Update()
  {

  }

  public void HidingInventory()
  {
    _sp.sprite = CloseInventory;

  }
  public void ShowingInventory()
  {
    _sp.sprite = OpenInventory;

  }

  void OnMouseDown()
  {
    if (!usingPockets)
    {
      _inventory.CheckItemLocation();
      _uiManager.ShowInventory();
    }

  }

}
