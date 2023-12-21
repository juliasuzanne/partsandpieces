using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float _moveSpeed = 2f;
    private bool moveable = true;
    [SerializeField]
    private bool grounded = false;
    Rigidbody2D rb;
    SpriteRenderer sp;
    private Animator _animator;
    [SerializeField]
    float _jumpForce = 9f;

    float xInput, yInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _animator = transform.GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        PlatformerMove();
        PlayerJump();
    }


    void PlayerJump()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 1f);
        Debug.DrawRay(transform.position, Vector2.down, Color.green);
        if (hit.collider != null)
        {
            grounded = true;
            Debug.Log(hit.collider.name);

        }
        else
        {
            grounded = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, _jumpForce);
            grounded = false;
        }
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
        _animator.SetFloat("yInput", Mathf.Abs(yInput));

        if (moveable == true)
        {
            FlipPlayer();
            _animator.SetFloat("xInput", Mathf.Abs(xInput));

            rb.velocity = new Vector2(_moveSpeed * xInput, rb.velocity.y);
        }
        else
        {
            Cursor.visible = true;
            _animator.SetFloat("xInput", xInput);

        }

    }

}
