using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartConditions : MonoBehaviour
{
    [SerializeField] List<GameObject> prefabs = new List<GameObject>();
    [SerializeField] List<SpriteRenderer> bootColor = new List<SpriteRenderer>();
    [SerializeField] List<SpriteRenderer> shirtColor = new List<SpriteRenderer>();
    [SerializeField] List<SpriteRenderer> skirtColor = new List<SpriteRenderer>();
    [SerializeField] List<SpriteRenderer> skinColor = new List<SpriteRenderer>();
    [SerializeField] List<SpriteRenderer> gloveColor = new List<SpriteRenderer>();
    [SerializeField] List<SpriteRenderer> lipColor = new List<SpriteRenderer>();
    private List<string> _savedObjects = new List<string>();
    private int count;
    [SerializeField] private CaveSaveSettings _saveSettings;
    [SerializeField] Inventory inventory;
    [SerializeField] UnityEvent onTrigger;
    [SerializeField] private GameObject extraArms;
    [SerializeField] private GameObject rainObject;
    [SerializeField] private GameObject baby;
    [SerializeField] private GameObject ticketButton;
    [SerializeField] private GameObject torso;


    // Start is called before the first frame update
    void Awake()
    {

        _saveSettings.LoadGame();
        _savedObjects = _saveSettings.so.inventoryitems;
        onTrigger.Invoke();
        foreach (GameObject item in prefabs)
        {
            if (_savedObjects.Contains(item.GetComponent<InventoryItem>().GetName()))
            {
                inventory.AddItemToInventory(item);
            }

        }

        foreach (SpriteRenderer sprite in bootColor)
        {
            sprite.color = _saveSettings.so.bootColor;
        }

        foreach (SpriteRenderer sprite in lipColor)
        {
            sprite.color = _saveSettings.so.lipColor;
        }

        foreach (SpriteRenderer sprite in gloveColor)
        {
            sprite.color = _saveSettings.so.gloveColor;

        }

        foreach (SpriteRenderer sprite in skirtColor)
        {
            sprite.color = _saveSettings.so.skirtColor;

        }

        foreach (SpriteRenderer sprite in shirtColor)
        {
            sprite.color = _saveSettings.so.shirtColor;
        }

        foreach (SpriteRenderer sprite in skinColor)
        {
            sprite.color = _saveSettings.so.skinColor;
        }



    }

    // Update is called once per frame
    void Update()
    {

    }

    void Start()
    {
        if (baby != null)
        {
            baby.SetActive(_saveSettings.so.hasBaby);
        }
        if (ticketButton != null)
        {
            ticketButton.SetActive(_saveSettings.so.hasTicket);
        }
        if (torso != null)
        {
            torso.SetActive(_saveSettings.so.hasTorso);
        }


        if (_saveSettings.so.hasExtraArms == true)
        {
            if (extraArms != null)
                extraArms.SetActive(true);

        }
        else if (_saveSettings.so.hasExtraArms == false)
        {
            if (extraArms != null)

                extraArms.SetActive(false);

        }

        if (_saveSettings.so.rain == true)
        {
            if (rainObject != null)
                rainObject.SetActive(true);

        }
        else if (_saveSettings.so.rain == false)
        {
            if (rainObject != null)

                rainObject.SetActive(false);

        }
    }
}
