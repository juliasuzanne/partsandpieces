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
    // Start is called before the first frame update
    void Start()
    {
        _afterChangePanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResumeGame()
    {
        _returnPanel.SetActive(true);
        _rockBridge.SetActive(false);
        this.gameObject.SetActive(false);

    }
}
