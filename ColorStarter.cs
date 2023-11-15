using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorStarter : MonoBehaviour
{
    private SpriteRenderer _sp;
    private Color m_NewColor;
    void Start()
    {
        _sp = GetComponent<SpriteRenderer>();
        m_NewColor = new Color(0f, 0f, 0f, 0.5f);
        _sp.color = m_NewColor;
    }


}
