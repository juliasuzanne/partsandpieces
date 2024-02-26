using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;

    //handle to animator
    // Start is called before the first frame update
    void Start()
    {
        //handle to animator
        _anim = gameObject.GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Move(float move)
    {
        move = Mathf.Abs(move);
        _anim.SetFloat("Move", move);

    }

    public void Jump(bool jump)
    {
        _anim.SetBool("Jumping", !jump);
    }

    public void Attack()
    {
        _anim.SetTrigger("Attack");
    }

}
