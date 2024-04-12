using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DrawingTogglerWindow : MonoBehaviour
{
    [SerializeField] private Sprite MazeDrawing;
    [SerializeField] private Sprite CityDrawing;
    [SerializeField] private Sprite _cityCurl;
    [SerializeField] private Sprite _mazeCurl;
    [SerializeField] private bool city;
    private SpriteRenderer _sp;
    [SerializeField] UnityEvent onChangeToMazeTrigger;
    [SerializeField] UnityEvent onChangeToCityTrigger;




    void Start()
    {
        _sp = transform.GetComponent<SpriteRenderer>();


    }

    void Update()
    {


    }

    public void ToggleDrawing()
    {
        if (_sp.sprite == CityDrawing)
        {
            city = false;
            _sp.sprite = MazeDrawing;
            onChangeToMazeTrigger.Invoke();
        }
        else
        {
            city = true;
            _sp.sprite = CityDrawing;
            onChangeToCityTrigger.Invoke();


        }


    }

    public bool GetCity()
    {
        return city;
    }

    public void ChangeCity(bool newCity)
    {
        city = newCity;
    }


    // void OnMouseEnter()
    // {
    //     if (city)
    //     {
    //         _sp.sprite = _cityCurl;


    //     }
    //     else
    //     {
    //         _sp.sprite = _mazeCurl;

    //     }

    // }

    // void OnMouseExit()
    // {
    //     if (city)
    //     {
    //         _sp.sprite = CityDrawing;

    //     }

    //     else
    //     {
    //         _sp.sprite = MazeDrawing;

    //     }
    // }


    void OnMouseDown()
    {
        ToggleDrawing();
    }

}
