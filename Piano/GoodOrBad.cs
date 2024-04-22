using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GoodOrBad : MonoBehaviour
{
    [SerializeField] private Text text;
    private int count;
    [SerializeField] private UnityEvent good;
    [SerializeField] private UnityEvent bad;

    private int goodLimit;
    private int badLimit;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        goodLimit = 2;
        badLimit = -2;
        text.text = "count is " + count;

    }


    public void Good()
    {
        count = count + 1;
        text.text = "count is " + count;

        if (count == goodLimit)
        {
            text.text = "good!";
            good.Invoke();
        }

    }
    public void Bad()
    {
        count = count - 1;
        text.text = "count is " + count;

        if (count == badLimit)
        {
            text.text = "bad!";
            bad.Invoke();
        }

    }
}
