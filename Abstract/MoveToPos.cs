using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPos : MonoBehaviour
{
    [SerializeField] private Vector2 moveToPos;
    [SerializeField] private bool move;
    [SerializeField] private bool usingY;

    [SerializeField] private float speed;
    [SerializeField] private Animator anim;

    void Start()
    {
        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }
    }

    void Update()
    {
        if (move == true)
        {
            anim.SetFloat("xInput", 1);
            anim.SetBool("Flip", true);
            MoveIntoPosition();
        }
        else
        {
            anim.SetFloat("xInput", 0);
            anim.SetBool("Flip", false);
        }
    }

    public void MoveToCorner()
    {
        move = true;
    }

    public void JumpToMove()
    {
        transform.position = new Vector2(moveToPos.x, moveToPos.y);
    }



    private void MoveIntoPosition()
    {

        Debug.Log(transform.position);
        var step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector2.MoveTowards(transform.position, moveToPos, step);
        if (usingY == true)
        {
            if (transform.position.y > 33f)
            {
                move = false;
            }
        }
        else
        {
            if (transform.position.x == moveToPos.x)
            {
                move = false;
            }
        }


    }
}
