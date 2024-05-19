using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DishController : MonoBehaviour
{
    private Vector3 _startingPos;
    private Vector3 _moveToPos;
    private GameObject _currentDish;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (_currentDish != null)
        {

            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 moveToPos = new Vector3(mousePosition.x, mousePosition.y);
            _currentDish.transform.position = moveToPos;

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

    public void DropItem()
    {
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
