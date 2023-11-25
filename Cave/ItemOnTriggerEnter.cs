using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemOnTriggerEnter : MonoBehaviour
{
    private string collisionGameobjectName;
    private Text description_text;
    private GameObject description_object;
    private bool _onPlayer;
    private AbovePlayer _abovePlayer;
    private CaveSaveSettings _caveSaveSettings;

    private Inventory _inventory;

    private InventoryItem _inventoryItem;
    public string Name = "item";

    private Image _image;
    private bool _filledWithWater;
    [SerializeField]
    private Sprite _filled, _empty;

    void Start()
    {
        _caveSaveSettings = GameObject.Find("SceneSaveSettings").GetComponent<CaveSaveSettings>();
        description_object = this.transform.GetChild(0).gameObject;
        description_text = this.transform.GetChild(0).GetComponent<Text>();
        _abovePlayer = GameObject.Find("AbovePlayer").GetComponent<AbovePlayer>();
        _inventory = GameObject.Find("Player").transform.GetComponent<Inventory>();
        _inventoryItem = this.gameObject.GetComponent<InventoryItem>();
        _image = GetComponent<Image>();
        _image.sprite = _empty;

    }

    private void FillRocksWithWater()
    {
        _filledWithWater = true;
        _image.sprite = _filled;
        Name = "three rocks full of reflective water";
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        INameable hit = other.GetComponent<INameable>();
        if (hit != null)
        {
            other.GetComponent<ApplySavedColor>().ApplyNameOnly();
            description_object.SetActive(true);
            description_text.text = "Use " + Name + " with " + hit.Name;
            if (other.gameObject.tag == "Player")
            {
                _onPlayer = true;
            }
            else if (hit.Name == "tears")
            {
                FillRocksWithWater();
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
        Debug.Log(_onPlayer);
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
