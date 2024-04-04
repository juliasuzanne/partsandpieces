using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChangeColorOnThis : MonoBehaviour, IChangeColor
{
  public string PartToApplyTo { get; set; }
  [SerializeField] private CaveSaveSettings _saveSettings;
  public bool changer { get; set; }
  [SerializeField] bool changing;

  void Start()
  {
    changer = changing;
  }

  void Update()
  {

  }


  public void ChangeBlue()
  {

  }
  public void ChangeWhite()
  {

  }
  public void ChangeBlack()
  {

  }
  public void ChangeRed()
  {

  }
  public void ChangeGreen()
  {

  }

}
