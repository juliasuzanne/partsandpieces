using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PalletteSlots : MonoBehaviour
{
    [SerializeField] private GameObject[] slots;
    [SerializeField] List<string> palletteItems = new List<string>();
    [SerializeField] List<string> itemsInPallette = new List<string>();
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
        palletteItems = saveSettings.so.windowsillitems;

        foreach (GameObject item in prefabs)
        {
            if (item.GetComponent<ChangeColorOnThis>().GetName() != null)
            {
                if (palletteItems.Contains(item.GetComponent<ChangeColorOnThis>().name))
                {
                    AddItemToPallette(item);
                }
            }

        }
    }

    public void AddItemToPallette(GameObject prefab)
    {
        count = 0;
        foreach (bool full in isFull)
        {
            if (full == false)
            {
                if (!itemsInPallette.Contains(prefab.GetComponent<ChangeColorOnThis>().name))
                {
                    Vector3 slotPos = new Vector3(slots[count].transform.position.x, slots[count].transform.position.y, 79f);
                    Debug.Log(count + " is FALSE");
                    isFull[count] = true;
                    Instantiate(prefab, slotPos, Quaternion.identity, slots[count].transform);
                    prefab.GetComponent<ChangeColorOnThis>().SetSlotPos(count);
                    itemsInPallette.Add(prefab.GetComponent<ChangeColorOnThis>().name);
                }
                else
                {
                    _dialog.SetActive(true);
                    _playerText.text = "I already have one of those";
                    break;
                }
                if (!saveSettings.so.windowsillitems.Contains(prefab.GetComponent<ChangeColorOnThis>().name))
                {
                    saveSettings.AddItemToWindowSill(prefab.GetComponent<ChangeColorOnThis>().name);
                }

                break;
            }

            else
            {
                if (count == slots.Length - 1)
                {
                    _dialog.SetActive(true);
                    _playerText.text = "I guess I need to get rid of something";
                    // StartCoroutine("PlayerSays");
                    break;
                }
            }
            count = count + 1;
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
