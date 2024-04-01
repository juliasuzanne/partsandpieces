using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float _moveSpeed = 2f;
    [SerializeField] private bool moveVertical;
    private bool moveable = true;
    [SerializeField]
    private bool grounded = false;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer sp;
    private Animator _animator;
    [SerializeField] private GameObject _umbrella;
    [SerializeField]
    float _jumpForce = 9f;

    float xInput, yInput;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        _animator = transform.GetChild(0).GetComponent<Animator>();
        sp = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // xInput = Input.GetAxis("Horizontal");
        // yInput = Input.GetAxis("Vertical");
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


    // void FlipPlayer()
    // {
    //     if (xInput < -0.0001f)
    //     {
    //         transform.eulerAngles = new Vector3(0, 0, 0);


    //     }
    //     else if (xInput > 0.0001f)
    //     {
    //         transform.eulerAngles = new Vector3(0, 180, 0);


    //     }
    // }

    public void MoveableFalse()
    {
        moveable = false;
    }

    public void MoveableTrue()
    {
        moveable = true;
    }

    public void GiveUmbrella()
    {
        _animator.SetBool("Umbrella", true);
        Debug.Log("got umbrella");
        _umbrella.SetActive(true);
    }

    public void RemoveUmbrella()
    {
        _animator.SetBool("Umbrella", false);
        _umbrella.SetActive(false);

    }

    public void SpeedUp(int newSpeed)
    {
        _moveSpeed = newSpeed;
    }

    void PlatformerMove()
    {
        // _animator.SetFloat("yInput", Mathf.Abs(yInput));

        // if (moveable == true)
        // {
        //     FlipPlayer();
        //     _animator.SetFloat("xInput", Mathf.Abs(xInput));
        //     rb.velocity = new Vector2(_moveSpeed * xInput, rb.velocity.y);
        // }
        // else
        // {
        //     Cursor.visible = true;
        //     // _animator.SetFloat("xInput", xInput);

        // }
        float horizontal = Input.GetAxisRaw("Horizontal"); //provides inputs, raw makes binary not float
        float vertical = Input.GetAxisRaw("Vertical");
        if (moveVertical == true)
        {
            vertical = Input.GetAxisRaw("Vertical");

        }
        else
        {
            vertical = 0;
        }
        FlipPlayer();

        rb.velocity = new Vector2(horizontal * _moveSpeed, vertical * _moveSpeed);

        // if (Input.GetKeyDown(KeyCode.Space) && _grounded == true)
        // {
        //     Debug.Log("space key down");
        //     rb.velocity = new Vector2(rb.velocity.x * _moveSpeed, _jumpForce);
        // }

        _animator.SetFloat("xInput", Mathf.Abs(horizontal));
        _animator.SetFloat("yInput", vertical);


    }

    void FlipPlayer()
    {


        if (rb.velocity.x > 0.1f)
        {
            sp.flipX = true;
            _umbrella.GetComponent<SpriteRenderer>().flipX = true;

        }
        else if (rb.velocity.x < -0.1f)
        {
            sp.flipX = false;
            _umbrella.GetComponent<SpriteRenderer>().flipX = false;




        }
    }



}
