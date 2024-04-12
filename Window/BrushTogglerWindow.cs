using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BrushTogglerWindow : MonoBehaviour
{
    [SerializeField] private GameObject BrushButton;
    [SerializeField] private GameObject BrushLive;
    [SerializeField] UnityEvent onTakeBrush;
    [SerializeField] UnityEvent onPutBrushBack;
    [SerializeField] private bool brushTaken;




    void Start()
    {
        brushTaken = false;


    }

    void Update()
    {

    }

    public void ToggleTakeBrush()
    {
        if (brushTaken == true)
        {
            brushTaken = false;
            BrushLive.SetActive(false);
            onPutBrushBack.Invoke();
        }
        else
        {
            brushTaken = true;
            BrushLive.SetActive(true);
            onTakeBrush.Invoke();


        }


    }


}
