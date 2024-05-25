using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemTrigger : MonoBehaviour
{
  [SerializeField] string itemName;
  private InventoryController _inventoryController;
  private Inventory _inventory;

  private CaveSaveSettings _saveSettings;

  public string Name { get; set; }

  [SerializeField] UnityEvent onTrigger;
  [SerializeField] bool destroyItemOnContact;
  [SerializeField] private GameObject itemToAdd;

  void Start()
  {
    _inventoryController = FindObjectOfType<InventoryController>();
    _saveSettings = FindObjectOfType<CaveSaveSettings>();
    _inventory = FindObjectOfType<Inventory>();


  }
  public void TriggerItem(string currentItemName)
  {

    if (itemName == currentItemName)
    {
      Debug.Log("Trigger" + currentItemName + " with " + itemName);
      if (destroyItemOnContact)
      {
        _inventoryController.GetCurrentItem().GetComponent<InventoryItem>().TriggerRemoveThisItem();
        if (itemToAdd != null)
        {
          _inventory.AddItemToInventory(itemToAdd);

        }

      }
      onTrigger.Invoke();
    }

  }
  public bool CheckMatch(string currentItemName)
  {
    if (itemName == currentItemName)
    {

      return true;
    }
    else
    {
      return false;
    }

  }



}