using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
   public bool[] isFull; // use to check if there is already an item in each slot
   public GameObject[] slots; // this to place items in the center of each slot, or drop
   public GameObject[] items; // 
   private int count = 0;
   [SerializeField] private Text _playerText;
   [SerializeField] private GameObject _dialog;
   [SerializeField] private CaveSaveSettings saveSettings;


   void Start()
   {
      if (_dialog == null)
      { _dialog = transform.GetChild(0).GetChild(0).gameObject; }
      _dialog.SetActive(false);

   }

   public void AddItemToInventory(GameObject prefab)
   {

      count = 0;
      foreach (bool full in isFull)
      {
         if (full == false)
         {
            Vector3 slotPos = new Vector3(slots[count].transform.position.x, slots[count].transform.position.y, 79f);
            Debug.Log(count + " is FALSE");
            items[count] = prefab;
            isFull[count] = true;
            Instantiate(prefab, slotPos, Quaternion.identity, slots[count].transform);
            prefab.GetComponent<InventoryItem>().SetSlotPos(count);
            if (!saveSettings.so.inventoryitems.Contains(prefab.GetComponent<InventoryItem>().GetName()))
            {
               saveSettings.SaveItemInInventory(prefab.GetComponent<InventoryItem>().GetName());
            }

            break;
         }

         else
         {
            if (count == slots.Length - 1)
            {
               _dialog.SetActive(true);
               _playerText.text = "I guess I need to get rid of something";
               StartCoroutine("PlayerSays");
               break;
            }
         }
         count = count + 1;
      }
   }

   public int CheckEmptySlots()
   {
      int numSlotsEmpty = 0;
      foreach (bool full in isFull)
      {
         if (full == false)
         {
            numSlotsEmpty = numSlotsEmpty + 1;
         }
      }
      return numSlotsEmpty;
   }

   public void CheckItemLocation()
   {
      count = 0;
      foreach (bool full in isFull)
      {
         if (full == true)
         {
            Vector3 slotPos = new Vector3(slots[count].transform.position.x, slots[count].transform.position.y, 0f);
            items[count].transform.position = slotPos;

         }
         count = count + 1;
      }
   }


   public void RemoveItemFromInventory(int slotNum)
   {
      if (slotNum == 100)
      {
         saveSettings.so.hasBaby = false;

      }
      else if (slotNum == 110)
      {
         saveSettings.so.hasTorso = false;

      }
      else if (slotNum == 120)
      {
         saveSettings.so.cutOffExtraArms = false;

      }
      else if (slotNum == 130)
      {
         saveSettings.so.hasTicket = false;

      }
      else
      {
         isFull[slotNum] = false;
         items[slotNum] = null;
         saveSettings.RemoveItemInInventory(slots[slotNum].transform.GetChild(0).GetComponent<InventoryItem>().GetName());
         Destroy(slots[slotNum].transform.GetChild(0).gameObject);
         saveSettings.SaveGame();
      }

   }


   IEnumerator PlayerSays()
   {
      yield return new WaitForSeconds(3f);
      _dialog.SetActive(false);

   }

}


