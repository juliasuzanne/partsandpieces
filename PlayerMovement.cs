using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float _moveSpeed = 2f;
    private bool moveable = false;
    Rigidbody2D rb;
    SpriteRenderer sp;
    private Animator _animator;
    float xInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _animator = transform.GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        FlipPlayer();
        PlatformerMove();
    }

    void FlipPlayer()
    {
        if (xInput < -0.0001f)
        {
            sp.flipX = false;
        }
        else if (xInput > 0.0001f)
        {
            sp.flipX = true;
        }
    }

    public void MoveableFalse()
    {
        moveable = false;
    }

    public void MoveableTrue()
    {
        moveable = true;
    }

    void PlatformerMove()
    {
        if (moveable == true)
        {
            _animator.SetFloat("xSpeed", Mathf.Abs(xInput));
            rb.velocity = new Vector2(_moveSpeed * xInput, 0);

        }
        else
        {
            Cursor.visible = true;
            _animator.SetFloat("xSpeed", Mathf.Abs(xInput));
        }

    }

}
