using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ToggleImageOnClick : MonoBehaviour
{
    [SerializeField] private Sprite FirstSprite;
    [SerializeField] private Sprite SecondSprite;

    [SerializeField] private bool toggled = false;
    [SerializeField] private Image _sp;
    [SerializeField] UnityEvent onChangeToFirst;

    [SerializeField] UnityEvent onChangeToSecond;




    void Start()
    {
        _sp = transform.GetComponent<Image>();


    }

    public void ToggleDrawing()
    {
        if (_sp.sprite == FirstSprite)
        {
            toggled = true;
            _sp.sprite = SecondSprite;
            onChangeToSecond.Invoke();
        }
        else
        {
            toggled = false;
            _sp.sprite = FirstSprite;
            onChangeToFirst.Invoke();
        }


    }

    void OnMouseDown()
    {
        Debug.Log("MOUSE DOWN ON PANEL");
        ToggleDrawing();
    }

}
