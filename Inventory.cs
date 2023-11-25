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
   private Text _playerText;
   private GameObject _dialog;


   void Start()
   {
      _dialog = transform.GetChild(0).GetChild(0).gameObject;
      _dialog.SetActive(false);
      _playerText = transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
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

   public void CheckItemLocation()
   {
      count = 0;
      foreach (bool full in isFull)
      {
         if (full == true)
         {
            Vector3 slotPos = new Vector3(slots[count].transform.position.x, slots[count].transform.position.y, 0f);
            items[count].transform.position = slotPos;
            break;
         }
         count = count + 1;
      }
   }


   public void RemoveItemFromInventory(int slotNum)
   {
      isFull[slotNum] = false;
      items[slotNum] = null;
   }


   IEnumerator PlayerSays()
   {
      yield return new WaitForSeconds(3f);
      _dialog.SetActive(false);

   }

}


