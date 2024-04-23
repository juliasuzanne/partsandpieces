using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StorageSlots : MonoBehaviour
{
    [SerializeField] private GameObject[] slots;
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] List<string> storageItems = new List<string>();
    [SerializeField] List<string> itemsInStorage = new List<string>();
    [SerializeField] bool[] isFull;
    private int slotNum;
    [SerializeField] private GameObject _dialog;
    [SerializeField] private Text _playerText;

    private int count;
    [SerializeField] GameObject[] prefabs;
    [SerializeField] private CaveSaveSettings saveSettings;
    // Start is called before the first frame update
    void Start()
    {
        storageItems = saveSettings.so.storageitems;

        foreach (GameObject item in prefabs)
        {
            if (item.GetComponent<FallingItem>().GetName() != null)
            {
                AddItemToStorage(item);
            }

        }
    }

    public void AddItemToStorage(GameObject prefab)
    {
        count = 0;

        foreach (bool full in isFull)
        {

            if (full == false)
            {
                if (!itemsInStorage.Contains(prefab.GetComponent<FallingItem>().GetName()))
                {
                    Vector3 slotPos = new Vector3(slots[count].transform.position.x, slots[count].transform.position.y, -1f);
                    Debug.Log(count + " is FALSE");
                    isFull[count] = true;
                    GameObject newPrefab = Instantiate(prefab, slotPos, Quaternion.identity, slots[count].transform);
                    newPrefab.GetComponent<FallingItem>().SetSlotNum(count);
                    newPrefab.GetComponent<FallingItem>().SetStorage(true);
                    itemsInStorage.Add(prefab.GetComponent<FallingItem>().GetName());
                    break;
                }
                else
                {
                    _dialog.SetActive(true);
                    _playerText.text = "I already have one of those";
                    break;
                }
                if (!saveSettings.so.storageitems.Contains(prefab.GetComponent<ChangeColorOnThis>().name))
                {
                    saveSettings.AddItemToStorage(prefab.GetComponent<FallingItem>().GetName());
                }

                break;
            }


            else
            {
                if (count == slots.Length - 1)
                {
                    _dialog.SetActive(true);
                    _playerText.text = "This box is too full.";
                    break;
                }
            }
            count = count + 1;
        }
    }
    // else
    // {
    //     _dialog.SetActive(true);
    //     _playerText.text = "This is already in here.";
    // }



    public void RemoveItemFromSlot(GameObject item)
    {
        itemsInStorage.Remove(item.GetComponent<FallingItem>().GetName());
        isFull[item.GetComponent<FallingItem>().GetSlotNum()] = false;
    }


    // Update is called once per frame
    void Update()
    {

    }
}
