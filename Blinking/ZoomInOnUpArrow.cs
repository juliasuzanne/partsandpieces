using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ZoomInOnUpArrow : MonoBehaviour
{
    [SerializeField] float scaler;
    [SerializeField] UnityEvent onTrigger;

    [SerializeField] private float _moveSpeed = 2f;
    private bool moveable = true;
    [SerializeField]
    private bool grounded = false;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer sp;
    // private Animator _animator;

    float xInput, yInput;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        // _animator = transform.GetChild(0).GetComponent<Animator>();
        sp = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // xInput = Input.GetAxis("Horizontal");
        // yInput = Input.GetAxis("Vertical");
        PlatformerMove();
        float alphaValue = (1f - (transform.localScale.x * 0.1f));
        sp.color = new Color(255f, 255f, 255f, alphaValue);
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
        float vertical = Input.GetAxisRaw("Vertical") * scaler; //provides inputs, raw makes binary not float

        Debug.Log(vertical);
        if (vertical > 0)
        {
            if (transform.localScale.x >= 2.5)
            {
                Debug.Log("over 2.5");
                // onTrigger.Invoke();


            }
            else
            {
                transform.localScale += new Vector3(vertical, vertical, vertical);

            }

        }
        else if (vertical < 0)
        {
            if (transform.localScale.x <= .75)
            {
                Debug.Log("less than .75");

            }
            else
            {
                transform.localScale -= new Vector3(-vertical, -vertical, -vertical);

            }
        }

    }



}
