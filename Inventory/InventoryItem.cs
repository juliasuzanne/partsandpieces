using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class InventoryItem : MonoBehaviour

{
    [SerializeField] UnityEvent onReturnToInventory;
    [SerializeField] private bool removeable;

    [SerializeField] bool consumable = false;
    [SerializeField] private GameObject prefabPickup;

    [SerializeField] private int slotNum;
    private Vector2 mousePosition;
    private float offsetX, offsetY;
    public static bool mouseButtonReleased = false;
    private Inventory _inventory;
    private InventoryController _inventoryController;
    private UIManager _uiManager;
    private INameable hit;
    [SerializeField] string Name;
    private StorageSlots storage;
    [SerializeField] bool returning = true;

    GameObject description_object;

    private Transform currentTransform;
    Text description_text;

    void Start()
    {
        if (FindObjectOfType<StorageSlots>() != null)
        {
            storage = FindObjectOfType<StorageSlots>();

        }
        _uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();

        _inventoryController = GameObject.Find("InventoryController").GetComponent<InventoryController>();
        _inventory = GameObject.Find("Player").transform.GetComponent<Inventory>();
        if (this.transform.GetChild(0) != null)
        {
            description_object = this.transform.GetChild(0).gameObject;
            description_text = this.transform.GetChild(0).GetComponent<Text>();
        }
        if (description_object != null)
        {
            description_object.SetActive(false);
        }
        if (Name == "torso")
        {
            SetSlotPos(110);
        }
        if (Name == "baby")
        {
            SetSlotPos(100);
        }
        if (Name == "cut off arms")
        {
            SetSlotPos(120);
        }
        if (Name == "ticket")
        {
            SetSlotPos(130);
        }


    }

    void Update()
    {
        if (this.gameObject == _inventoryController.GetCurrentItem())
        {
            if (description_object != null)
            {
                description_object.SetActive(true);
            }
            if (currentTransform != null)
            {
                Debug.Log("current Transform" + currentTransform.name);
            }

            if (mouseButtonReleased == true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (hit == null)
                    {
                        ReturnToInventory();
                    }
                    else if (hit.Name == "trashbin")
                    {
                        RemoveThisItem();
                    }
                    else if (hit.Name == "storage drawer")
                    {
                        StoreThisItem();
                    }
                    else
                    {
                        ItemTrigger[] triggers = currentTransform.GetComponentsInChildren<ItemTrigger>();


                        foreach (ItemTrigger trigger in triggers)
                        {

                            trigger.TriggerItem(this.Name);

                            if (this.Name == "knife")
                            {
                                _inventory.RemoveItemFromInventory(slotNum);
                                _inventory.AddBloodyKnife();
                            }


                            if (consumable == true && trigger.CheckMatch(Name) == true)
                            {
                                Debug.Log("CheckMatch is true");
                                if (slotNum < 90)
                                {
                                    _inventory.RemoveItemFromInventory(slotNum);

                                }
                                Destroy(this.gameObject);
                            }

                        }

                        if (returning == true)
                        {
                            ReturnToInventory();

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
        // if (description_object != null)
        // {
        //     description_object.SetActive(false);
        // }

    }

    public void RemoveThisItem()
    {
        if (removeable == true)
        {
            _inventory.RemoveItemFromInventory(slotNum);
            _inventoryController.MakeItemNull();
            // Destroy(this.gameObject);
        }

    }
    public void StoreThisItem()
    {
        if (prefabPickup != null)
        {
            storage.AddItemToStorage(prefabPickup);
            _inventory.RemoveItemFromInventory(slotNum);
            _inventoryController.MakeItemNull();
            Destroy(this);
        }

        // Instantiate(prefabPickup, new Vector2(Random.Range(-1f, 3f), Random.Range(-1f, 3f)), Quaternion.identity);

    }

    public void SetSlotPos(int num)
    {
        slotNum = num;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        hit = other.GetComponent<INameable>();


        if (hit != null)
        {
            currentTransform = other.transform;
            Debug.Log("HIT: " + hit.Name);

            if (description_text != null)
            {
                description_text.text = "Use " + Name + " with " + hit.Name;

            }
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        hit = null;
        currentTransform = null;

        if (description_text != null)
        {
            description_text.text = "Use " + Name + " with... ";

        }
        onReturnToInventory.Invoke();
    }

    public string GetName()
    {
        return Name;
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

