using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemTrigger : MonoBehaviour
{
  [SerializeField] string itemName;
  public string Name { get; set; }

  [SerializeField] UnityEvent onTrigger;

  void Start()
  {
  }
  public void TriggerItem(string currentItemName)
  {

    if (itemName == currentItemName)
    {
      Debug.Log("Trigger" + currentItemName + " with " + itemName);
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