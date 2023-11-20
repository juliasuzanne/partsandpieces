using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetColor : MonoBehaviour
{

  [SerializeField]
  private GameObject _greenSetter, _redSetter, _blueSetter;

  private float _red, _blue, _green;

  private DragMirror _mirrorB, _mirrorM, _mirrorT;

  private Image _image;
  private SpriteRenderer _sp;
  private Color m_NewColor;
  [SerializeField]
  private GameObject _colorChangePanel;

  void Start()
  {
    _mirrorT = _redSetter.GetComponent<DragMirror>();
    _mirrorM = _greenSetter.GetComponent<DragMirror>();
    _mirrorB = _blueSetter.GetComponent<DragMirror>();
    _sp = GetComponent<SpriteRenderer>();
    _image = GetComponent<Image>();
  }

  void Update()
  {
    _green = (_greenSetter.transform.position.x - _mirrorB.minX) * (1 / _mirrorB.xRange);
    _red = (_redSetter.transform.position.x - _mirrorB.minX) * (1 / _mirrorB.xRange);
    _blue = (_blueSetter.transform.position.x - _mirrorB.minX) * (1 / _mirrorB.xRange);
    m_NewColor = new Color(_red, _green, _blue, 1f);
    if (_colorChangePanel.activeSelf == true)
    {
      if (_image != null)
      {
        _image.color = m_NewColor;

      }
      if (_sp != null)
      {
        _sp.color = m_NewColor;
      }
    }


  }
}