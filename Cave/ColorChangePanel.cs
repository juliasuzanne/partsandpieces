using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangePanel : MonoBehaviour
{

    [SerializeField]
    private GameObject _colorPanel;

    [SerializeField]
    private GameObject _rockBridge;
    [SerializeField]
    private GameObject _afterChangePanel;
    [SerializeField]
    private GameObject _lastPanel;
    [SerializeField]
    private GameObject _returnPanel;
    [SerializeField]
    private GameObject _rockFace;
    [SerializeField]
    private GameObject _abovePlayer;
    private float m_Red, m_Blue, m_Green;
    private CaveSaveSettings _caveSaveSettings;

    private ApplySavedColor _applyColor;
    private ApplySavedColor _applyColor2;

    private UIManager _uiManager;

    // Start is called before the first frame update
    void Awake()
    {
        _caveSaveSettings = GameObject.Find("SceneSaveSettings").GetComponent<CaveSaveSettings>(); _afterChangePanel.SetActive(true);
        _applyColor = _abovePlayer.GetComponent<ApplySavedColor>();
        _applyColor2 = GameObject.FindGameObjectWithTag("Player").GetComponent<ApplySavedColor>();
        _uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        if (_uiManager == null)
        {
            Debug.Log("UI MANAGER IS NULL ON COLOR PANEL, READING " + _uiManager);
        }


    }

    public void showColorChangePanel()
    {
        _uiManager.HideInventoryWithButton();
        _rockFace.SetActive(false);
        _abovePlayer.SetActive(false);
    }

    public void ResumeGame()
    {
        _rockFace.SetActive(true);
        _returnPanel.SetActive(true);
        _abovePlayer.SetActive(true);
        SaveColor();
        _applyColor.ApplyColor();
        _applyColor2.ApplyColor();
        _applyColor.ApplyColor();
        _applyColor2.ApplyColor();
        //ADD SCRIPT TO APPLY COLOR TO PLAYER
        _rockBridge.SetActive(false);
        // _player.MoveableTrue();
        Cursor.visible = true;
        _lastPanel.SetActive(true);
        _uiManager.ShowInventoryButton();
        _colorPanel.SetActive(false);
        this.gameObject.SetActive(false);


    }

    public void SetColor(float red_m, float green_m, float blue_m)
    {
        m_Blue = blue_m;
        m_Green = green_m;
        m_Red = red_m;
    }

    public void SaveColor()
    {
        _caveSaveSettings.SaveColor(m_Red, m_Green, m_Blue, 1f);
        _caveSaveSettings.SaveGame();
        _applyColor.ApplyColor();
        _applyColor2.ApplyColor();
    }
}
