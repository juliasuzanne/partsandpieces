using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChangeColorOnThis : MonoBehaviour, IChangeColor
{
  public string PartToApplyTo { get; set; }

  [SerializeField] string name;
  private int slotNum;
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

  public string GetName()
  {
    return name;
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
      case "boots":
        {
          _saveSettings.so.bootColor = new Color(m_red, m_blue, m_green);
          break;
        }
      case "lips":
        {
          _saveSettings.so.lipColor = new Color(m_red, m_blue, m_green);
          break;
        }
      case "gloves":
        {
          _saveSettings.so.gloveColor = new Color(m_red, m_blue, m_green);
          break;
        }
      case "skin":
        {
          _saveSettings.so.skinColor = new Color(m_red, m_blue, m_green);
          break;
        }
    }
  }

  public void SetSlotPos(int num)
  {
    slotNum = num;
  }


  void Update()
  {

  }



}
