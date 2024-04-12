using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageCurlOnHover : MonoBehaviour
{
    [SerializeField] private Sprite _cityCurl;
    [SerializeField] private Sprite _mazeCurl;
    [SerializeField] private Sprite _mazeDraw;
    [SerializeField] private Sprite _cityDraw;
    [SerializeField] private DrawingTogglerWindow toggler;
    [SerializeField] private SpriteRenderer sp;
    private bool city;

    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseEnter()
    {
        city = toggler.GetCity();
        if (city)
        {
            sp.sprite = _cityCurl;
            toggler.ChangeCity(false);


        }
        else
        {
            sp.sprite = _mazeCurl;
            toggler.ChangeCity(true);

        }

    }

    void OnMouseExit()
    {
        city = toggler.GetCity();
        if (city)
        {
            sp.sprite = _cityDraw;

        }

        else
        {
            sp.sprite = _mazeDraw;

        }
    }
}
