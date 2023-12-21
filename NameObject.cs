using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameObject : MonoBehaviour, INameable
{
    public string Name { get; set; }
    [SerializeField] private string _defaultName;
    void Start()
    {
        Name = _defaultName;
    }

    public void ChangeName(string name)
    {
        Name = name;
    }

}
