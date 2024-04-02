using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IItemable
{
    string Name { get; set; }
    void TriggerItem();
}
