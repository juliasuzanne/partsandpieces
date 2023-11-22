using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangePanel : MonoBehaviour
{
    [SerializeField]
    private GameObject _rockBridge;
    [SerializeField]
    private GameObject _afterChangePanel;
    [SerializeField]
    private GameObject _returnPanel;
    [SerializeField]
    private GameObject _abovePlayer;
    [SerializeField]
    private GameObject _rockFace;
    // Start is called before the first frame update
    void Start()
    {
        _abovePlayer = GameObject.Find("AbovePlayer");
        _rockFace = GameObject.Find("Set_Background").transform.GetChild(3).transform.GetChild(1).gameObject;
        _afterChangePanel.SetActive(true);
        _abovePlayer.SetActive(false);
        _rockFace.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResumeGame()
    {
        _rockFace.SetActive(true);
        _abovePlayer.SetActive(true);
        _returnPanel.SetActive(true);
        _rockBridge.SetActive(false);
        this.gameObject.SetActive(false);

    }
}
