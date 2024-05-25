using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToInventoryOnClick : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    private Inventory _inventory;
    // Start is called before the first frame update
    void Start()
    {
        _inventory = GameObject.Find("Player").transform.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        _inventory.AddItemToInventory(prefab);
        Destroy(this.gameObject);
    }
}
