using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChanger : MonoBehaviour
{

    Rigidbody2D rb;
    private PlayerMovement _playerMovement;
    private Animator _animator;
    private Animator _robotAnimator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _playerMovement = GetComponent<PlayerMovement>();
        _animator = GetComponent<Animator>();
        if (GameObject.Find("RobotArm") != null)
        {
            _robotAnimator = GameObject.Find("RobotArm").GetComponent<Animator>();

        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.transform.name);
        if (other.transform.name == "RockBridge")
        {
            _robotAnimator.SetTrigger("Open");
            // _animationController.AnimatorWalking();
            _animator.SetTrigger("Land");
            SetGravity(2f);

        }
    }

    public void Fall(float fallSpeed)
    {
        _playerMovement.MoveableTrue();

        _animator.SetTrigger("Fall");
        SetGravity(fallSpeed);

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
