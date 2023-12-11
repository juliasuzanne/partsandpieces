using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INameable
{
  string itemName;
  bool combinable;

  void Use();

  void Combine();

}