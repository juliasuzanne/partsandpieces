using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICookable
{
    string Name { get; set; }
    string SecondName { get; set; }
    string ThirdName { get; set; }
    int requestId { get; set; }

    bool GetEnabled();

    void SetRequestorId(int newId);

    string Type { get; set; }
    void Match(GameObject currentObj);
    void NoMatch();


}