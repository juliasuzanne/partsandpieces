using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTriggerOnClick : MonoBehaviour
{
    [SerializeField]
    private string _triggerName;
    [SerializeField]
    private float _secondsToDestroy;
    [SerializeField]
    private bool _destroy = true;

    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        _animator.SetTrigger(_triggerName);
        if (_destroy == true)
        {
            Destroy(this.gameObject, _secondsToDestroy);
        }
    }
}
