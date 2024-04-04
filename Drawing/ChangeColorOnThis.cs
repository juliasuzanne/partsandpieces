using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChangeColorOnThis : MonoBehaviour, IChangeColor
{
  public string PartToApplyTo { get; set; }
  [SerializeField] private CaveSaveSettings _saveSettings;
  public bool changer { get; set; }
  public Color newColor { get; set; }

  [SerializeField] bool changing;
  [SerializeField] string whichColorToChange;

  void Start()
  {
    PartToApplyTo = whichColorToChange;
    changer = changing;
  }

  public void UpdateColor(float m_red, float m_blue, float m_green)
  {
    switch (PartToApplyTo)
    {
      case "skirt":
        {
          _saveSettings.so.skirtColor = new Color(m_red, m_blue, m_green);
          break;
        }
      case "shirt":
        {
          _saveSettings.so.shirtColor = new Color(m_red, m_blue, m_green);
          break;
        }
      case "boot":
        {
          _saveSettings.so.bootColor = new Color(m_red, m_blue, m_green);
          break;
        }
    }
  }



  void Update()
  {

  }



}
