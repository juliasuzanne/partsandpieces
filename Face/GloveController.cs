using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloveController : MonoBehaviour
{
    private Vector3 _startingPos;
    private Vector3 _moveToPos;
    private GameObject _currentGlove;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (_currentGlove != null)
        {

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 moveToPos = new Vector3(mousePosition.x, mousePosition.y, 0f);
            _currentGlove.transform.position = moveToPos;

        }

    }

    public GameObject GetCurrentItem()
    {
        return _currentGlove;
    }


    public void ChangeItem(GameObject item)
    {
        _currentGlove = item;

    }

    public void DropItem()
    {
        _currentGlove = null;

    }

    public void MakeItemNull()
    {
        if (_currentGlove != null)
        {
            Vector3 posToMove = new Vector3(_currentGlove.transform.position.x, _currentGlove.transform.position.y, _currentGlove.transform.position.z);
            _currentGlove.transform.position = posToMove;
            _currentGlove = null;

        }


    }



}
