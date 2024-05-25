using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {

    }
    void OnMouseDown()
    {
        Debug.Log("Mouse Down on Test Object");
    }

    void OnMouseEnter()
    {
        Debug.Log("Mouse entered on Test Object");
    }


}
