using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCoin : MonoBehaviour
{
    private AdjustCoinCount adjustCoinCount;
    // Start is called before the first frame update
    void Start()
    {
        adjustCoinCount = FindObjectOfType<AdjustCoinCount>();
    }

    void OnMouseDown()
    {
        adjustCoinCount.AddCoin();
        Destroy(this.gameObject);
    }



}
