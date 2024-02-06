using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INoteable
{
  public string GetNote();
  public void SuccessNote();
  public void WrongNote();
  public void AfterEnter();
  public void AfterExit();



}