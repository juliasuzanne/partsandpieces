using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplySavedColor : MonoBehaviour
{
    private CaveSaveSettings _caveSaveSettings;
    private SpriteRenderer _sp;

    // Start is called before the first frame update
    void Start()
    {
        _caveSaveSettings = GameObject.Find("SceneSaveSettings").GetComponent<CaveSaveSettings>();
        _sp = GetComponent<SpriteRenderer>();

    }

    public void ApplyColor()
    {
        _sp.color = new Color(_caveSaveSettings.so.red, _caveSaveSettings.so.green, _caveSaveSettings.so.blue, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
