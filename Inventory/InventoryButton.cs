using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class InventoryButton : MonoBehaviour
{
  [SerializeField] private Sprite OpenInventory;
  [SerializeField] private Sprite CloseInventory;
  [SerializeField] private Inventory _inventory;
  private UIManager _uiManager;
  private SpriteRenderer _sp;
  [SerializeField] UnityEvent onTrigger;
  [SerializeField] bool usingPockets = true;
  [SerializeField] private PlayerMovement playerMovement;



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
    // playerMovement.MoveableFalse();

  }
  public void ShowingInventory()
  {
    _sp.sprite = OpenInventory;
    // playerMovement.MoveableTrue();


  }

  void OnMouseDown()
  {
    if (!usingPockets)
    {
      onTrigger.Invoke();
      _inventory.CheckItemLocation();
      _uiManager.ShowInventory();
    }

  }

}
