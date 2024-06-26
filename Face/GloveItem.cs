using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class GloveItem : MonoBehaviour

{
  [SerializeField] UnityEvent onReturnToInventory;
  [SerializeField] bool consumable = false;
  private int slotNum;
  private Vector2 mousePosition;
  private float offsetX, offsetY;
  public static bool mouseButtonReleased = false;
  private Inventory _inventory;
  private InventoryController _inventoryController;
  private UIManager _uiManager;
  private INameable hit;
  [SerializeField] string Name;
  GameObject description_object;
  private Transform currentTransform;
  Text description_text;
  //need reference to virtualcam, c_VirtualCamera.m_LookAt = target.transform;
  //change which item is moved
  //stop moving on key press
  //reference to glove controller

  void Start()
  {
    _uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
    _inventoryController = GameObject.Find("InventoryController").GetComponent<InventoryController>();
    _inventory = GameObject.Find("Player").transform.GetComponent<Inventory>();
    if (this.transform.GetChild(0) != null)
    {
      description_object = this.transform.GetChild(0).gameObject;
      description_text = this.transform.GetChild(0).GetComponent<Text>();
    }

  }

  void Update()
  {

    if (mouseButtonReleased == true)
    {
      if (Input.GetMouseButtonDown(0))
      {
        if (hit == null)
        {
          ReturnToInventory();
        }
        else
        {
          ItemTrigger[] triggers = currentTransform.GetComponentsInChildren<ItemTrigger>();

          foreach (ItemTrigger trigger in triggers)
          {
            trigger.TriggerItem(Name);
            if (consumable == true && trigger.CheckMatch(Name) == true)
            {
              Debug.Log("CheckMatch is true");
              _inventory.RemoveItemFromInventory(slotNum);
              Destroy(this.gameObject);
            }

          }


        }
      }
    }
    else
    {
      if (description_object != null)
      {
        description_object.SetActive(false);
      }

    }
  }

  public void SetSlotPos(int num)
  {
    slotNum = num;
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    hit = other.GetComponent<INameable>();
    currentTransform = other.transform;

    Debug.Log("HIT: " + hit.Name);
    if (hit != null)
    {
      if (description_text != null)
      {
        description_text.text = "Use " + Name + " with " + hit.Name;

      }
    }

  }

  void OnTriggerExit2D(Collider2D other)
  {
    hit = null;
    if (description_text != null)
    {
      description_text.text = "Use " + Name + " with... ";

    }
    onReturnToInventory.Invoke();
    currentTransform = null;
  }


  public void UseItem()
  {
    if (description_object != null)
    {
      description_object.SetActive(true);

    }
    _inventoryController.ChangeItem(this.gameObject);
    mouseButtonReleased = true;
  }


  public void ReturnToInventory()
  {
    onReturnToInventory.Invoke();
    if (description_object != null)
    {
      description_object.SetActive(false);
    }
    _inventoryController.MakeItemNull();
    mouseButtonReleased = false;
  }

}





