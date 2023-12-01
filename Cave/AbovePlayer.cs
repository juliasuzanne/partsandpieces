using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbovePlayer : MonoBehaviour
{
  private GameObject _rockFaces;
  [SerializeField]
  private ColorChangePanel _colorChangePanelScript;

  [SerializeField]

  private GameObject _colorChangePanel;

  void Start()
  {
    _rockFaces = GameObject.Find("Set_Background").transform.GetChild(3).GetChild(1).gameObject;

  }

  public void showColorChangePanel()
  {
    this.gameObject.SetActive(false);
    _rockFaces.SetActive(false);
    _colorChangePanel.SetActive(true);
    Cursor.visible = false;
    _colorChangePanelScript.showColorChangePanel();
  }

}
