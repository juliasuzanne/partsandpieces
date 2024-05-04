using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GoodOrBad : MonoBehaviour
{
    // [SerializeField] private Text text;
    private int count;
    [SerializeField] private UnityEvent good;

    [SerializeField] private UnityEvent bad;

    // // Start is called before the first frame update
    void Start()
    {
        count = 0;
        // text.text = "count is " + count;

    }

    public void GetCount()
    {
        Debug.Log("CALCULATED COUNT:" + count);

        if (count > 5)
        {
            good.Invoke();
        }
        else
        {
            bad.Invoke();
        }
    }


    public void Good()
    {
        count = count + 1;
        // text.text = "count is " + count;
        Debug.Log("GOOD, COUNT:" + count);


    }
    public void Bad()
    {
        count = count - 1;
        Debug.Log("BAD, COUNT:" + count);
        // text.text = "count is " + count;

    }
}
