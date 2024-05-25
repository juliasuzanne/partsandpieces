using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleScene : MonoBehaviour
{
    private UIManager _uiManager;

    // Start is called before the first frame update
    void Awake()
    {
        _uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        // _uiManager.LoadGame();
        // Debug.Log("Hello??");

    }

    // Update is called once per frame
    void Update()
    {

    }
}
