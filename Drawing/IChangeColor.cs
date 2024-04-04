using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IChangeColor
{
    string PartToApplyTo { get; set; }
    Color newColor { get; set; }
    bool changer { get; set; }
    void UpdateColor(float m_red, float m_blue, float m_green);

}
