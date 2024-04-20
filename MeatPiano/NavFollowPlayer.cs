using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavFollowPlayer : MonoBehaviour
{
    private Vector3 target;
    [SerializeField] private Transform followPlayer;
    [SerializeField] private Animator _anim;
    private Transform thisAgent;
    NavMeshAgent agent;
    private float xInput, yInput, xControl, yControl;


    // Start is called before the first frame update
    void Awake()
    {
        agent = this.GetComponent<NavMeshAgent>();
        thisAgent = this.transform;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        SetTargetPosition();
        SetAgentPosition();
        if (_anim != null)
        {
            xInput = followPlayer.position.x - thisAgent.position.x;
            yInput = followPlayer.position.y - thisAgent.position.y;
            Debug.Log("X: " + xInput + " Y: " + yInput);
            _anim.SetFloat("yInput", yControl);
            _anim.SetFloat("xInput", Mathf.Abs(xControl));

            if (Mathf.Abs(xInput) > Mathf.Abs(yInput))
            {
                xControl = xInput;
                yControl = 0;
                if (xInput < 0)
                {
                    _anim.SetBool("Flip", false);
                }
                else
                {
                    _anim.SetBool("Flip", true);

                }


            }
            else if (Mathf.Abs(yInput) > Mathf.Abs(xInput))
            {
                xControl = 0;
                yControl = yInput;

            }





        }





    }

    void SetTargetPosition()
    {
        target = new Vector3(followPlayer.position.x, followPlayer.position.y, followPlayer.position.z);
    }

    void SetAgentPosition()
    {
        // Debug.Log("target = " + target);
        agent.SetDestination(new Vector3(target.x, target.y, transform.position.z));
    }
}
