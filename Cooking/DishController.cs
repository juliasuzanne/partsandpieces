using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DishController : MonoBehaviour
{
    private Vector3 _startingPos;
    private GameObject player;
    private Vector3 _moveToPos;
    private GameObject _currentDish;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("CURRENTDISH:" + _currentDish);

        if (_currentDish != null)
        {

            // Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Vector2 moveToPos = new Vector3(mousePosition.x, mousePosition.y);
            // _currentDish.transform.position = moveToPos;

        }
        else
        {

        }
        if (Input.GetKeyDown("x"))
        {
            Debug.Log("X key was pressed");
            DropItem();

        }



    }

    public GameObject GetCurrentItem()
    {
        return _currentDish;
    }


    public void ChangeItem(GameObject item)
    {
        _currentDish = item;
        // c_VirtualCamera.m_LookAt = item.transform.GetChild(1).transform;
        // c_VirtualCamera.m_Follow = item.transform.GetChild(1).transform;

    }

    public void GiveItemToPlayer(GameObject item)
    {
        _currentDish = item;
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        _currentDish.transform.position = new Vector2(player.transform.GetChild(7).position.x, player.transform.GetChild(7).position.y);
        _currentDish.transform.parent.GetComponent<BoxCollider2D>().enabled = true;
        _currentDish.transform.SetParent(player.transform.GetChild(7));

    }

    public void DropItem()
    {
        _currentDish = null;
    }

    public void DropItemToLocation(Transform location)
    {
        Vector2 posToMove = new Vector2(location.position.x, location.position.y);
        _currentDish.transform.position = posToMove;
        _currentDish.transform.SetParent(location);
        _currentDish = null;
    }


    public void MakeItemNull()
    {
        if (_currentDish != null)
        {
            Vector2 posToMove = new Vector2(_currentDish.transform.position.x, _currentDish.transform.position.y);
            _currentDish.transform.position = posToMove;
            _currentDish = null;

        }


    }



}
