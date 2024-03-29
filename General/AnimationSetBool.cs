using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSetBool : MonoBehaviour
{
    [SerializeField] string collidedObjectName, animName;
    [SerializeField] private Animator anim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == collidedObjectName)
        {
            anim.SetBool(animName, true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == collidedObjectName)
        {
            anim.SetBool(animName, false);
        }
    }

}
