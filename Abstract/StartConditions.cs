using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartConditions : MonoBehaviour
{
    [SerializeField] List<GameObject> prefabs = new List<GameObject>();
    private List<string> _savedObjects = new List<string>();
    private int count;
    [SerializeField] private CaveSaveSettings _saveSettings;

    [SerializeField] Inventory inventory;
    [SerializeField] UnityEvent onTrigger;

    // Start is called before the first frame update
    void Start()
    {
        _savedObjects = _saveSettings.so.inventoryitems;
        onTrigger.Invoke();
        foreach (GameObject item in prefabs)
        {
            if (_savedObjects.Contains(item.GetComponent<InventoryItem>().GetName()))
            {
                inventory.AddItemToInventory(item);
            }

        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
