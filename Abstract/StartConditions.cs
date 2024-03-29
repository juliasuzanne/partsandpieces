using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartConditions : MonoBehaviour
{
    [SerializeField] GameObject prefab1;
    [SerializeField] GameObject prefab2;
    [SerializeField] GameObject prefab3;
    [SerializeField] Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory.AddItemToInventory(prefab1);
        inventory.AddItemToInventory(prefab2);
        inventory.AddItemToInventory(prefab3);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
