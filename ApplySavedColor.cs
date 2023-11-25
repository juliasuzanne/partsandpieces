using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplySavedColor : MonoBehaviour, INameable
{
    private CaveSaveSettings _caveSaveSettings;
    private SpriteRenderer _sp;
    public string Name { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _caveSaveSettings = GameObject.Find("SceneSaveSettings").GetComponent<CaveSaveSettings>();
        _sp = GetComponent<SpriteRenderer>();

    }

    public void ApplyColor()
    {
        _sp.color = new Color(_caveSaveSettings.so.red, _caveSaveSettings.so.green, _caveSaveSettings.so.blue, 1f);
        Name = _caveSaveSettings.so.playerName;
    }

    public void ApplyNameOnly()
    {
        Name = _caveSaveSettings.so.playerName;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
