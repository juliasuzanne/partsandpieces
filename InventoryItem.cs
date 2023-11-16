using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour

{
    private Vector2 mousePosition;
    private float offsetX, offsetY;
    public static bool mouseButtonReleased = false;
    private Transform _item;
    private Vector3 startingPos;
    private Inventory _inventory;
    private InventoryController _inventoryController;

    void Start()
    {
        startingPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        _inventoryController = GameObject.Find("InventoryController").GetComponent<InventoryController>();
        _inventory = GameObject.Find("Player").transform.GetComponent<Inventory>();

    }

    void Update()
    {
        if (mouseButtonReleased == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StopMoving();
            }
        }
    }

    public void UseItem()
    {
        _inventoryController.ChangeItem(this.transform, startingPos);
        mouseButtonReleased = true;
    }

    private void StopMoving()
    {
        _inventoryController.MakeItemNull();
        mouseButtonReleased = false;
    }
}

