using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private Inventory _inventory;
    private Vector3 _startingPos;
    private Vector3 _moveToPos;
    private GameObject _item;
    // Start is called before the first frame update
    void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<Inventory>();

    }

    // Update is called once per frame
    void Update()
    {

        if (_item != null)
        {

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 moveToPos = new Vector3(mousePosition.x, mousePosition.y, 0f);
            _item.transform.position = moveToPos;

        }

    }

    public GameObject GetCurrentItem()
    {
        return _item;
    }


    public void ChangeItem(GameObject item)
    {
        _item = item;

    }

    public void DropItem()
    {
        _item = null;

    }

    public void MakeItemNull()
    {
        if (_item != null)
        {
            Vector3 posToMove = new Vector3(_item.transform.parent.position.x, _item.transform.parent.position.y, _item.transform.parent.position.z);
            _item.transform.position = posToMove;
            _item = null;

        }


    }



}