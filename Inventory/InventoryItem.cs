using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour

{
    private Vector2 mousePosition;
    private float offsetX, offsetY;
    public static bool mouseButtonReleased = false;
    private Inventory _inventory;
    private InventoryController _inventoryController;
    private UIManager _uiManager;
    private INameable hit;
    [SerializeField] string Name;
    GameObject description_object;
    Text description_text;

    void Start()
    {

        _uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        _inventoryController = GameObject.Find("InventoryController").GetComponent<InventoryController>();
        _inventory = GameObject.Find("Player").transform.GetComponent<Inventory>();
        description_object = this.transform.GetChild(0).gameObject;
        description_text = this.transform.GetChild(0).GetComponent<Text>();
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
                    Debug.Log("USE ITEM: " + Name);
                    hit.UsingItem(Name);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        hit = other.GetComponent<INameable>();

        Debug.Log("HIT: " + hit.Name);
        if (hit != null)
        {
            description_text.text = "Use " + Name + " with " + hit.Name;
        }
        else
        {
            description_text.text = "Use " + Name + " with... ";
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        hit = null;
        description_text.text = "Use " + Name + " with... ";
    }


    public void UseItem()
    {
        description_object.SetActive(true);
        _inventoryController.ChangeItem(this.gameObject);
        description_text.text = "Use " + Name + " with... ";
        mouseButtonReleased = true;
    }


    public void ReturnToInventory()
    {
        description_object.SetActive(false);
        _inventoryController.MakeItemNull();
        mouseButtonReleased = false;
    }

}

