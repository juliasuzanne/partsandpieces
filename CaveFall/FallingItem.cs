using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingItem : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private StorageSlots storageManager;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private int slotPos;
    [SerializeField] private CaveSaveSettings _saveSettings;
    [SerializeField] private PlayerSpeech _playerSpeech;
    [SerializeField] private bool storage = false;

    // Start is called before the first frame update
    void Start()
    {
        _uiManager = FindObjectOfType<UIManager>();

        _inventory = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<Inventory>();
        if (_saveSettings == null)
        {
            _saveSettings = FindObjectOfType<CaveSaveSettings>();
        }
        _playerSpeech = FindObjectOfType<PlayerSpeech>();
        if (FindObjectOfType<StorageSlots>() != null)
        {
            storageManager = FindObjectOfType<StorageSlots>();
        }

    }

    void OnMouseDown()
    {
        if (!_saveSettings.so.inventoryitems.Contains(prefab.GetComponent<InventoryItem>().GetName()))
        {
            _inventory.AddItemToInventory(prefab);

            if (storage == true)
            {
                _saveSettings.so.storageitems.Remove(prefab.GetComponent<InventoryItem>().GetName());
                storageManager.RemoveItemFromSlot(this.gameObject);

            }
            _uiManager.PulseInventoryButton();
            Destroy(this.gameObject);
        }
        else
        {
            if (_playerSpeech != null)
            {
                _playerSpeech.PlayerTalkingForSeconds("I already have one of those.");

            }
        }

    }



    public string GetName()
    {
        return prefab.GetComponent<InventoryItem>().GetName();
    }

    public void SetStorage(bool state)
    {
        storage = state;
    }

    public void SetSlotNum(int slotId)
    {
        slotPos = slotId;
    }

    public int GetSlotNum()
    {
        return slotPos;
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

