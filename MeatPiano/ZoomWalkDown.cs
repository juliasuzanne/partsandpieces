using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ZoomWalkDown : MonoBehaviour
{
    [SerializeField] float scaler, scaleMax, scaleMin;
    [SerializeField] bool scaling = false;

    [SerializeField] UnityEvent onTrigger;

    [SerializeField] private float _moveSpeed;
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
        float alphaValue = (255f - (transform.localScale.x * 10f));
        sp.color = new Color(255f, alphaValue, 255f);
    }


    public void MoveableFalse()
    {
        moveable = false;
    }

    public void MoveableTrue()
    {
        moveable = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "scalearea")
        {
            Debug.Log("enter scaling");
            scaling = true;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "scalearea")
        {
            Debug.Log("leave scaling");
            scaling = false;

        }
    }


    void PlatformerMove()
    {
        float vertical = Input.GetAxisRaw("Vertical") * scaler; //provides inputs, raw makes binary not float
        if (scaling == true)
        {
            if (vertical > 0)
            {
                if (transform.localScale.x <= scaleMin)
                {
                    // Debug.Log("ChangeScene");
                    // onTrigger.Invoke();
                }
                else
                {
                    transform.localScale -= new Vector3(vertical, vertical, vertical);

                }

            }
            else if (vertical < 0)
            {
                if (transform.localScale.x >= scaleMax)
                {

                }
                else
                {
                    transform.localScale += new Vector3(-vertical, -vertical, -vertical);

                }
            }
        }

    }


}
