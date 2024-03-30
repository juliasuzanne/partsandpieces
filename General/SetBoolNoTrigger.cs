using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBoolNoTrigger : MonoBehaviour
{
    [SerializeField] private string animName;
    [SerializeField] private Animator anim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetAnimBoolTrue()
    {
        {
            anim.SetBool(animName, true);
        }
    }

    public void SetAnimBoolFalse()
    {
        {
            anim.SetBool(animName, false);
        }
    }
}
