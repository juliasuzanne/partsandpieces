using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckSaveSettings : MonoBehaviour
{
    [SerializeField]
    private CaveSaveSettings _saveSettings;
    [SerializeField]
    string[] _strings;
    [SerializeField]
    Text[] _texts;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RevealSaveSettings()
    {
        _texts[0].text = _saveSettings.so.playerName;
        _texts[1].text = _saveSettings.so.rockName;
        _texts[2].text = "" + _saveSettings.so.red + "";
        _texts[3].text = "" + _saveSettings.so.blue + "";
        _texts[4].text = "" + _saveSettings.so.green + "";


    }
}
