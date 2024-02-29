using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseableItem : MonoBehaviour

{
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
  // GameObject description_object;
  private Transform currentTransform;
  // Text description_text;

  void Start()
  {
    _uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
    _inventoryController = GameObject.Find("InventoryController").GetComponent<InventoryController>();
    _inventory = GameObject.Find("Player").transform.GetComponent<Inventory>();
    // description_object = this.transform.GetChild(0).gameObject;
    // description_text = this.transform.GetChild(0).GetComponent<Text>();
  }

  void Update()
  {
    if (mouseButtonReleased = true)
    {

      if (Input.GetMouseButtonDown(0))
      {
        Debug.Log("REGISTER BUTTON DOWN");
        if (hit == null)
        {
        }
        else if (hit.Name == "plate")
        {
          Debug.Log("HIT PLATE TRIGGER");

          ItemTrigger trigger = transform.GetComponent<ItemTrigger>();
          trigger.TriggerItem("plate");
          _inventoryController.DropItem();
          hit = null;
          mouseButtonReleased = false;
          currentTransform = null;


        }

      }
    }

    else
    {
      // description_object.SetActive(false);

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
    if (hit != null)
    {
      Debug.Log("HIT: " + hit.Name);

    }


  }

  void OnTriggerExit2D(Collider2D other)
  {
    hit = null;
    mouseButtonReleased = false;
    currentTransform = null;
  }


  public void UseItem()
  {
    // description_object.SetActive(true);
    _inventoryController.ChangeItem(this.gameObject);
    mouseButtonReleased = true;
  }



}

