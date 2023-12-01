using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItemSO", menuName = "InventoryItemSO", order = 0)]
public class InventoryItemSO : ScriptableObject
{
    public float cost;
    public bool disposable;

}