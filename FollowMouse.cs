using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _sp;
    [SerializeField]
    private Sprite _downMouse;
    [SerializeField]
    private Sprite _upMouse;

    // Start is called before the first frame update
    void Start()
    {
        _sp.sprite = _upMouse;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        transform.position = mousePos2D;
        if (Input.GetMouseButtonDown(0))
        {
            _sp.sprite = _downMouse;
        }
        if (Input.GetMouseButtonUp(0))
        {
            _sp.sprite = _upMouse;
        }

    }

}

