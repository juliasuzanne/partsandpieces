using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesFollow : MonoBehaviour
{
    private float _originalX, _originalY, _distanceX, _distanceY, _parentX, _parentY, _newPosX, _newPosY;
    [SerializeField]
    private Transform followObject;

    [SerializeField]
    private float _yScaler, _xScaler, _xMin, _xMax, _yMin, _yMax;
    private Vector2 _newPos, _mousePos;

    [SerializeField] private bool _uiObject;
    // Start is called before the first frame update
    void Start()
    {
        _parentX = transform.parent.position.x;
        _parentY = transform.parent.position.y;
        _originalX = transform.position.x;
        _originalY = transform.position.y;

        _xMin = _originalX + _xMin;
        _xMax = _originalX + _xMax;
        _yMin = _originalY + _yMin;
        _yMax = _originalY + _yMax;



    }

    // Update is called once per frame
    void Update()
    {


        if (followObject == null)
        {
            _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else
        {
            _mousePos = new Vector2(followObject.position.x, followObject.position.y);
        }

        if (_uiObject)
        {
            _newPosX = _mousePos.x * _xScaler - _originalX;
            _newPosY = _mousePos.y * _yScaler - _originalY;
        }
        else
        {
            _distanceX = _mousePos.x - _originalX;
            _distanceY = _mousePos.y - _originalY;
            _newPosX = _parentX + _distanceX * _xScaler;
            _newPosY = _parentY + _distanceY * _yScaler;

        }

        if (_newPosX < _xMin)
        {
            _newPosX = _xMin;
        }
        else if (_newPosX > _xMax)
        {
            _newPosX = _xMax;
        }

        if (_newPosY < _yMin)
        {
            _newPosY = _yMin;
        }
        else if (_newPosY > _yMax)
        {
            _newPosY = _yMax;
        }



        transform.position = new Vector2(_newPosX, _newPosY);



    }

}
