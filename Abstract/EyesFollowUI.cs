using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesFollowUI : MonoBehaviour
{
    [SerializeField] private float xPos, yPos;
    [SerializeField] private float _yScaler, _xScaler, xMin, xMax, yMin, yMax;
    private float _newPosX, _newPosY, _distanceX, _distanceY;
    private Vector2 _newPos, _mousePos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _mousePos = Input.mousePosition;

        _distanceX = _mousePos.x - xPos;
        _distanceY = _mousePos.y - yPos;
        _newPosX = xPos + _distanceX * _xScaler;
        _newPosY = yPos + _distanceY * _yScaler;

        // // transform.position = new Vector2(xPos + (_xScaler * _mousePos.x), yPos + (_yScaler * _mousePos.y));
        // if (_newPosX < xMin)
        // {
        //     _newPosX = xMin;
        // }
        // else if (_newPosX > xMax)
        // {
        //     _newPosX = xMax;
        // }

        // if (_newPosY < yMin)
        // {
        //     _newPosY = yMin;
        // }
        // else if (_newPosY > yMax)
        // {
        //     _newPosY = yMax;
        // }

        transform.position = new Vector2(_newPosX, _newPosY);



    }
}
