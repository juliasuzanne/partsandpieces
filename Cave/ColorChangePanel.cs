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
    private GameObject _returnPanel;

    private GameObject _rockFace;
    [SerializeField]
    private GameObject _abovePlayer;

    // Start is called before the first frame update
    void Start()
    {
        _afterChangePanel.SetActive(true);
        _rockFace = GameObject.Find("Set_Background").transform.GetChild(3).transform.GetChild(1).gameObject;

    }

    public void showColorChangePanel()
    {
        _rockFace.SetActive(false);
        _abovePlayer.SetActive(false);
    }

    public void ResumeGame()
    {
        _rockFace.SetActive(true);
        _returnPanel.SetActive(true);
        _abovePlayer.SetActive(true);
        //ADD SCRIPT TO APPLY COLOR TO PLAYER
        _rockBridge.SetActive(false);
        this.gameObject.SetActive(false);
        // _player.MoveableTrue();
        _colorPanel.SetActive(false);



    }
}
