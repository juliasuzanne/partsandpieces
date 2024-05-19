using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICookable
{
    string Name { get; set; }
    string SecondName { get; set; }
    string ThirdName { get; set; }


    string Type { get; set; }
    void Match();
    void NoMatch();


}