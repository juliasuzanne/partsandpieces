using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCaveFall : MonoBehaviour
{
    private ApplySavedColor _applySave;
    private CaveSaveSettings _saveSettings;
    // Start is called before the first frame update
    void Start()
    {
        _applySave = GameObject.Find("Player").GetComponent<ApplySavedColor>();
        _saveSettings = GameObject.Find("SceneSaveSettings").GetComponent<CaveSaveSettings>();
        _saveSettings.LoadGame();
        _applySave.ApplyColor();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
