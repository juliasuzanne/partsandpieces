using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartConditions : MonoBehaviour
{
    [SerializeField] GameObject prefab1;
    [SerializeField] GameObject prefab2;
    [SerializeField] GameObject prefab3;

    [SerializeField] Inventory inventory;
    [SerializeField] UnityEvent onTrigger;

    // Start is called before the first frame update
    void Start()
    {
        onTrigger.Invoke();
        if (prefab1 != null)
        {
            inventory.AddItemToInventory(prefab1);

        }
        if (prefab2 != null)
        {
            inventory.AddItemToInventory(prefab2);

        }
        if (prefab3 != null)
        {
            inventory.AddItemToInventory(prefab3);

        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
