using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour

{
    private Vector2 mousePosition;
    private float offsetX, offsetY;
    public static bool mouseButtonReleased = false;
    private Inventory _inventory;
    private InventoryController _inventoryController;

    void Start()
    {
        _inventoryController = GameObject.Find("InventoryController").GetComponent<InventoryController>();
        _inventory = GameObject.Find("Player").transform.GetComponent<Inventory>();
    }

    void Update()
    {

        if (mouseButtonReleased == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ReturnToInventory();
            }

        }
    }


    public void UseItem()
    {
        _inventoryController.ChangeItem(this.gameObject);
        mouseButtonReleased = true;
    }


    public void ReturnToInventory()
    {
        _inventoryController.MakeItemNull();
        mouseButtonReleased = false;
    }

}

