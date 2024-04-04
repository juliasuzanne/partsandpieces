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

    public void ToggleAnimBool()
    {
        if (anim.GetBool(animName))
        {
            anim.SetBool(animName, false);
        }
        else if (!anim.GetBool(animName))
        {
            anim.SetBool(animName, true);

        }
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
