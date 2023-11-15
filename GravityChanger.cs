using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChanger : MonoBehaviour
{

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    public void SetGravity(float _speed)
    {
        rb.gravityScale = _speed;
    }

    public void SetGravityToZero()
    {
        rb.gravityScale = 0;
    }
}
