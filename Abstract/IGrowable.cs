using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGrowable
{
    public float startingTime { get; set; }
    public SpriteRenderer sp { get; set; }
    public Sprite[] sprites { get; set; }
    public float growingTime { get; set; }
    public bool growing { get; set; }

    public void SetStartingTime();

}