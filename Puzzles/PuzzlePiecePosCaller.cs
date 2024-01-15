using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiecePosCaller : MonoBehaviour, IPlaceable
{
  private IPlaceable hit;
  [SerializeField] private int puzzleIdentifier;
  public int puzzleID
  {
    get
    {
      return puzzleIdentifier;
    }
  }


}
