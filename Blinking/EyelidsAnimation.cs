using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyelidsAnimation : MonoBehaviour
{
    [SerializeField] float scaler;
    [SerializeField] string lid;

    [SerializeField]
    private float _moveSpeed = 2f;
    private bool moveable = true;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer sp;
    // private Animator _animator;

    float xInput, yInput;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        Move();
        // float alphaValue = (1f - (transform.localScale.x * 0.1f));
        // sp.color = new Color(255f, 255f, 255f, alphaValue);
    }


    public void MoveableFalse()
    {
        moveable = false;
    }

    public void MoveableTrue()
    {
        moveable = true;
    }

    void Move()
    {
        float vertical = Input.GetAxisRaw("Vertical") * scaler; //provides inputs, raw makes binary not float
        Debug.Log(vertical);
        if (lid == "up")
        {
            if (transform.position.y > 16 || transform.position.y < -2)
            {
                rb.velocity = new Vector2(0, 0);

            }
            else if (vertical > 0 || vertical < 0)
            {
                rb.velocity = new Vector2(rb.velocity.x * _moveSpeed, vertical);
            }
            else
            {
                rb.velocity = new Vector2(0, 0);

            }

        }
        else if (lid == "down")
        {
            if (transform.position.y < -16)
            {
                rb.velocity = new Vector2(0, 0);

            }
            else if (vertical > 0 || vertical < 0)
            {
                rb.velocity = new Vector2(rb.velocity.x * _moveSpeed, -vertical);

            }
            else
            {
                rb.velocity = new Vector2(0, 0);

            }
        }

    }


}
