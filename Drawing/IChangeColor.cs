using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IChangeColor
{
    string PartToApplyTo { get; set; }
    bool changer { get; set; }
    void ChangeBlue();
    void ChangeWhite();
    void ChangeBlack();
    void ChangeRed();
    void ChangeGreen();
}
