using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbovePlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject _colorChangePanel;

    public void showColorChangePanel()
    {
        _colorChangePanel.SetActive(true);
    }
}
