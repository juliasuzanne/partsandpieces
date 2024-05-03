using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavShowPlayer : MonoBehaviour
{
    private Vector3 target;
    [SerializeField] private Transform followPlayer;
    [SerializeField] private Transform waitForPlayer;

    [SerializeField] private Animator _anim;
    [SerializeField] private AudioSource audioSource;
    private Transform thisAgent;
    [SerializeField] NavMeshAgent agent;
    private float xInput, yInput, xControl, yControl;


    // Start is called before the first frame update
    void Awake()
    {
        agent = this.GetComponent<NavMeshAgent>();
        thisAgent = this.transform;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    public void ChangeTargetDestination(Transform newTarget)
    {
        followPlayer = newTarget;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("CORNER0: " + agent.path.corners[0]);
        if (agent.path.corners.Length > 1)
        {
            Debug.Log("CORNER1: " + agent.path.corners[1]);
            Debug.Log("DIRECTION?: " + Vector3.Distance(agent.path.corners[0], agent.path.corners[1]));

        }

        // Vector3.Distance(agent.path.corners[0], agent.path.corners[1])

        SetTargetPosition();
        SetAgentPosition();

        if (audioSource != null)
        {
            float distance = Vector3.Distance(thisAgent.position, followPlayer.transform.position);
            float newPitch = (distance / 10);
            if (newPitch > 3)
            {
                newPitch = 3f;
            }
            else if (newPitch < 0.1)
            {
                newPitch = 0.1f;
            }
            else
            {
                newPitch = (distance / 10);
            }
            audioSource.pitch = newPitch;

        }

        if (_anim != null)
        {

            // xInput = followPlayer.position.x - thisAgent.position.x;
            // yInput = followPlayer.position.y - thisAgent.position.y;
            if (agent.path.corners.Length > 1)
            {
                xInput = agent.path.corners[1].x - agent.path.corners[0].x;
                yInput = agent.path.corners[1].y - agent.path.corners[0].y;
            }


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
            else
            {
                yControl = 0;
                xControl = 0;
            }





        }





    }

    void SetTargetPosition()
    {
        float distanceToPlayer = Vector3.Distance(thisAgent.position, waitForPlayer.transform.position);
        if (distanceToPlayer < 10f)
        {
            target = new Vector3(followPlayer.position.x, followPlayer.position.y, followPlayer.position.z);

        }
        else
        {
            target = new Vector3(thisAgent.position.x, thisAgent.position.y, thisAgent.position.z);
            yControl = 0;
            xControl = 0;

        }

    }

    void SetAgentPosition()
    {
        // Debug.Log("target = " + target);
        agent.SetDestination(new Vector3(target.x, target.y, transform.position.z));
    }
}
