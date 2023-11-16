using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetColor : MonoBehaviour
{

  [SerializeField]
  private GameObject _greenSetter, _redSetter, _blueSetter;

  private float _red, _blue, _green;

  private Image _image;
  private Color m_NewColor;

  void Start()
  {
    _image = GetComponent<Image>();
    Debug.Log(_green);
  }

  void Update()
  {
    _green = _greenSetter.transform.position.x * 0.04f;
    m_NewColor = new Color(0.5f, 0.5f, _green, 1f);
    _image.color = m_NewColor;
    Debug.Log(m_NewColor);
    Debug.Log("Green " + _green);
  }
}