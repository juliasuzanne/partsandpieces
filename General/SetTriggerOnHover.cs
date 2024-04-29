using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SetTriggerOnHover : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private UnityEvent _onMouseEnter;
    [SerializeField] private UnityEvent _onMouseExit;


    // Start is called before the first frame update

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }
    private void OnMouseEnter()
    {
        if (_anim != null)
        {
            _anim.SetBool("Hover", true);

        }
        _onMouseEnter.Invoke();

    }

    private void OnMouseExit()
    {
        if (_anim != null)
        {
            _anim.SetBool("Hover", false);

        }
        _onMouseExit.Invoke();
    }

}
