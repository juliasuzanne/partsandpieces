using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    private SpriteRenderer _sp;
    private Color m_NewColor;
    float m_Red, m_Blue, m_Green;

    [SerializeField]
    private GameObject _colorPanel;
    private PlayerMovement _player;
    private float posX;
    private float posY;
    [SerializeField]
    private float alphaStart = 0.7f;
    // Start is called before the first frame update
    void Start()
    {

        sp = GetComponent<SpriteRenderer>();
        player = transform.GetComponent<Hand>();
        colorPanel.SetActive(false);
        _uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        // Debug.Log("Blue: " + _uiManager.so.blue);
        // redSlider.value = _uiManager.so.red;
        // greenSlider.value = _uiManager.so.green;
        // blueSlider.value = _uiManager.so.blue;
        _uiManager.SaveColor(0, 0, 0, alphaStart);

        Debug.Log("Sp color:" + sp.color);
        m_NewColor = new Color(_uiManager.so.red, _uiManager.so.green, _uiManager.so.blue, alphaStart);

        sp.color = m_NewColor;

    }

    void Update()
    {
        Debug.Log("Sp color:" + sp.color);

    }

    public void SetColor(float red_m, float green_m, float blue_m)
    {
        m_Blue = blue_m;
        m_Green = green_m;
        m_Red = red_m;
        Color newColor = new Color(red_m, green_m, blue_m, 1f);
        sp.color = new Color(red_m, green_m, blue_m, 1f);
    }


    public void ChangeColor()
    {
        colorPanel.SetActive(true);
        player.MoveableFalse();

    }

    public void ResumeGame()
    {
        player.MoveableTrue();
        _uiManager.SaveColor(m_Red, m_Green, m_Blue, 1f);
        _uiManager.SaveGame();
        colorPanel.SetActive(false);

    }

}