using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeavingPanel : MonoBehaviour
{
    [SerializeField]
    private Text _text;
    [SerializeField]
    private string[] strings;
    private int count = 0;

    void Start()
    {

    }
    void OnMouseDown()
    {
        if (count < strings.Length)
        {
            count = count + 1;
            _text.text = strings[count];
            _text.enabled = true;
        }

        else
        {
            _text.enabled = false;
        }
    }

}
