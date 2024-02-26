using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformerPlayer : MonoBehaviour, IDamageable
{
    [SerializeField]
    public int diamonds = 0;
    [SerializeField]
    public int Health { get; set; }
    [SerializeField]
    private Text currencyText;
    [SerializeField]
    private float h_speed = 1;
    [SerializeField]
    private int _jumpForce = 5;
    [SerializeField]
    private bool _grounded = false;
    private Rigidbody2D _rigb;
    [SerializeField]

    private PlayerAnimation _playeranim;
    [SerializeField]
    private SpriteRenderer _playersprite;
    private Transform _hitBox;



    //get reference to rigidbody
    void Start()
    {
        //assign handle of rigidbody
        _rigb = gameObject.GetComponent<Rigidbody2D>();
        _playeranim = gameObject.GetComponent<PlayerAnimation>();
        _hitBox = this.gameObject.transform.GetChild(0).transform;
        _playersprite = this.gameObject.GetComponentInChildren<SpriteRenderer>();

        if (_playersprite == null)
        {
            Debug.Log("The sprite renderer is NULL");
        }
        FlipPlayer();
        currencyText.text = "CURRENCY: " + diamonds;



    }

    // Update is called once per frame
    void Update()
    {
        CheckGrounded();
        PlayerMove();
        if (_grounded == true && Input.GetMouseButtonDown(0) == true)
        {
            Attack();
        }
        //if left click, attack

        //instead of transform translate, modify velocity of player
        //horizontal input for left and right
        //current velocity = new velocity Vector2(horizontal input, current velocity.y)
        // cast ray for physics 2d, playerposition down to ground
    }


    void CheckGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 1.0f, 1 << 8);
        Debug.DrawRay(transform.position, -Vector2.up, Color.green);

        if (hit.collider != null)
        {
            float distance = Mathf.Abs(hit.point.y - transform.position.y);
            // Debug.Log("distance " + distance);
            _grounded = true;
            _playeranim.Jump(_grounded);

        }
        else
        {
            _grounded = false;
            _playeranim.Jump(_grounded);

        }
    }

    void PlayerMove()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); //provides inputs, raw makes binary not float
        FlipPlayer();

        Debug.Log(horizontal);

        _rigb.velocity = new Vector2(horizontal * h_speed, _rigb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && _grounded == true)
        {
            Debug.Log("space key down");
            _rigb.velocity = new Vector2(_rigb.velocity.x * h_speed, _jumpForce);
        }

        _playeranim.Move(horizontal);
    }

    void FlipPlayer()
    {
        Debug.Log(_hitBox.name);

        if (_rigb.velocity.x > 0.1f)
        {
            // _playersprite.flipX = false;
            // Debug.Log("not flipped");
            _hitBox.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (_rigb.velocity.x < -0.1f)
        {
            // _playersprite.X = true;
            // Debug.Log("flipped");
            // _hitBox.eulerAngles = new Vector3(0, 0, 0);
            _hitBox.eulerAngles = new Vector3(0, 0, 0);


        }
    }



    public void AddDiamonds(int diamondsToAdd)
    {
        diamonds = diamonds + diamondsToAdd;
        currencyText.text = "CURRENCY: " + diamonds;

    }

    public void RemoveDiamonds(int diamondsToRemove)
    {
        diamonds -= diamondsToRemove;
        currencyText.text = "CURRENCY: " + diamonds;

    }

    private void Attack()
    {
        _playeranim.Attack();

    }

    public void Damage()
    {
        Debug.Log("Player Damaged");

    }
}
