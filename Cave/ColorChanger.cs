using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    private Color m_NewColor;
    float m_Red, m_Blue, m_Green;
    private CaveSaveSettings _caveSaveSettings;

    [SerializeField]
    private GameObject _colorPanel;
    private GameObject _abovePlayer;
    [SerializeField]
    private ApplySavedColor _applyColor;
    private ApplySavedColor _applyColor2;




    void Start()
    {
        _abovePlayer = GameObject.Find("AbovePlayer");
        _applyColor = _abovePlayer.GetComponent<ApplySavedColor>();
        _caveSaveSettings = GameObject.Find("SceneSaveSettings").GetComponent<CaveSaveSettings>();
        _applyColor2 = GameObject.FindGameObjectWithTag("Player").GetComponent<ApplySavedColor>();
        _colorPanel.SetActive(false);
    }


    public void SetColor(float red_m, float green_m, float blue_m)
    {
        m_Blue = blue_m;
        m_Green = green_m;
        m_Red = red_m;
        Color newColor = new Color(red_m, green_m, blue_m, 1f);
    }


    public void ResumeGame()
    {
        _abovePlayer.SetActive(true);
        _caveSaveSettings.SaveColor(m_Red, m_Green, m_Blue, 1f);
        _caveSaveSettings.SaveGame();
        _applyColor.ApplyColor();
        _applyColor2.ApplyColor();
        _colorPanel.SetActive(false);

    }

}