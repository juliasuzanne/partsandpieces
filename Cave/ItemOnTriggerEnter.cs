using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public abstract class ItemOnTriggerEnter : MonoBehaviour
{
    protected string collisionGameobjectName;
    protected Text description_text;
    protected GameObject description_object;
    protected bool _onPlayer;
    protected AbovePlayer _abovePlayer;
    protected CaveSaveSettings _caveSaveSettings;

    protected Inventory _inventory;

    protected InventoryItem _inventoryItem;
    public string Name = "item";
    [SerializeField]
    protected string _changedName;

    protected Image _image;
    protected bool _changed = false;
    [SerializeField]
    protected Sprite _starting, _completed;

    void Start()
    {
        _caveSaveSettings = GameObject.Find("SceneSaveSettings").GetComponent<CaveSaveSettings>();
        description_object = this.transform.GetChild(0).gameObject;
        description_text = this.transform.GetChild(0).GetComponent<Text>();
        _abovePlayer = GameObject.Find("AbovePlayer").GetComponent<AbovePlayer>();
        _inventory = GameObject.Find("Player").transform.GetComponent<Inventory>();
        _inventoryItem = this.gameObject.GetComponent<InventoryItem>();
        _image = GetComponent<Image>();
        _image.sprite = _starting;

    }

    protected void ChangeSprite()
    {
        _changed = true;
        _image.sprite = _completed;
        Name = _changedName;
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        INameable hit = other.GetComponent<INameable>();
        if (hit != null)
        {
            description_object.SetActive(true);
            description_text.text = "Use " + Name + " with " + hit.Name;
            if (other.gameObject.tag == "Player")
            {
                _onPlayer = true;
            }

        }


    }

    void OnTriggerExit2D(Collider2D collision)
    {
        description_object.SetActive(false);
        description_text.text = "";
        _onPlayer = false;

    }

    void Update()
    {
        // Debug.Log(_onPlayer);
        if (Input.GetMouseButtonDown(0))
        {
            if (_onPlayer == true)
            {
                _abovePlayer.showColorChangePanel();
                description_object.SetActive(false);
                description_text.text = "";
            }


        }

    }

}
