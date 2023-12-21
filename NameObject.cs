using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameObject : MonoBehaviour, INameable
{
    public string Name { get; set; }
    [SerializeField] private string _defaultName;

    void Start()
    {
        if (Name == null)
        {
            Name = _defaultName;
        }
    }

    public void UsingItem(string itemName)
    {
        if (itemName == "needle and thread")
        {
            Debug.Log("I like to sew");
        }
    }



}
