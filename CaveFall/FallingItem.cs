using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingItem : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private CaveSaveSettings _saveSettings;
    [SerializeField] private PlayerSpeech _playerSpeech;

    // Start is called before the first frame update
    void Start()
    {

        _inventory = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<Inventory>();
        _saveSettings = FindObjectOfType<CaveSaveSettings>();
        _playerSpeech = FindObjectOfType<PlayerSpeech>();

    }

    void OnMouseDown()
    {
        if (!_saveSettings.so.inventoryitems.Contains(prefab.GetComponent<InventoryItem>().GetName()))
        {
            _inventory.AddItemToInventory(prefab);
            Destroy(this.gameObject);
        }
        else
        {
            _playerSpeech.PlayerTalkingForSeconds("I already have one of those.");
        }

    }

    public void GiveItem()
    {
        if (!_saveSettings.so.inventoryitems.Contains(prefab.GetComponent<InventoryItem>().GetName()))
        {
            _inventory.AddItemToInventory(prefab);
            Destroy(this.gameObject);
        }
        else
        {
            _playerSpeech.PlayerTalkingForSeconds("I already have one of those.");
        }
    }
}

