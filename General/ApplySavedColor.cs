using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplySavedColor : MonoBehaviour
{
    [SerializeField]
    private CaveSaveSettings _caveSaveSettings;

    [SerializeField]
    private SpriteRenderer _sp;
    public string Name { get; set; }

    // Start is called before the first frame update
    void Start()
    {

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
