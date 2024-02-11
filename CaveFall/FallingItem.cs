using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingItem : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Inventory _inventory;

    // Start is called before the first frame update
    void Start()
    {

        _inventory = GameObject.Find("Player").transform.GetComponent<Inventory>();

    }

    void OnMouseDown()
    {
        _inventory.AddItemToInventory(prefab);
        Destroy(this.gameObject);
    }

    public void GiveItem()
    {
        _inventory.AddItemToInventory(prefab);
        Destroy(this.gameObject);
    }
}

