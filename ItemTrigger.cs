using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemTrigger : MonoBehaviour
{
  [SerializeField] string itemName;
  [SerializeField] UnityEvent onTrigger;

  public void TriggerItem(string currentItemName)
  {
    if (itemName == currentItemName)
    {
      onTrigger.Invoke();
    }
  }

}