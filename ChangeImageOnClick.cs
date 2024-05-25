using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImageOnClick : MonoBehaviour
{
    [SerializeField]
    private Sprite OpenBox;
    [SerializeField]
    private Sprite CloseBox;

    private Image _image;
    // Start is called before the first frame update
    void Start()
    {
        _image = transform.GetComponent<Image>();
        Debug.Log("Image: " + _image);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnToggleImage()
    {
        if (_image.sprite.name == "CloseBox")
        {
            _image.sprite = OpenBox;
        }
        else
        {
            _image.sprite = CloseBox;
        }
    }
}
