using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeQuest : MonoBehaviour
{
    [SerializeField] private Text _questText;
    [SerializeField] private CaveSaveSettings _saveSettings;

    void Start()
    {
        if (_questText.text == "")
        {
            _questText.text = "Explore";
        }
    }

    public void UpdateQuest(string newQuest)
    {
        _questText.text = newQuest;
        _saveSettings.ChangeQuest(newQuest);
    }
}
