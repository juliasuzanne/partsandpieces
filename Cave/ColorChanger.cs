using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    private SpriteRenderer _sp;
    private Color m_NewColor;
    float m_Red, m_Blue, m_Green;
    private CaveSaveSettings _caveSaveSettings;

    [SerializeField]
    private GameObject _colorPanel;
    private PlayerMovement _player;
    private GameObject _abovePlayer;
    private float posX;
    private float posY;
    [SerializeField]
    private ApplySavedColor _applyColor;



    void Start()
    {
        _abovePlayer = GameObject.Find("AbovePlayer");
        _applyColor = _abovePlayer.GetComponent<ApplySavedColor>();
        _caveSaveSettings = GameObject.Find("SceneSaveSettings").GetComponent<CaveSaveSettings>();
        _sp = GetComponent<SpriteRenderer>();
        _player = transform.GetComponent<PlayerMovement>();
        _colorPanel.SetActive(false);
    }


    public void SetColor(float red_m, float green_m, float blue_m)
    {
        m_Blue = blue_m;
        m_Green = green_m;
        m_Red = red_m;
        Color newColor = new Color(red_m, green_m, blue_m, 1f);
        _sp.color = new Color(red_m, green_m, blue_m, 1f);
    }


    public void ChangeColor()
    {
        _colorPanel.SetActive(true);
        _player.MoveableFalse();

    }

    public void ResumeGame()
    {
        _abovePlayer.SetActive(true);
        _caveSaveSettings.SaveColor(m_Red, m_Green, m_Blue, 1f);
        _caveSaveSettings.SaveGame();
        _applyColor.ApplyColor();
        _colorPanel.SetActive(false);

    }

}