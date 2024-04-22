using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavFollowPlayer : MonoBehaviour
{
    private Vector3 target;
    [SerializeField] private Transform followPlayer;
    [SerializeField] private Animator _anim;
    [SerializeField] private AudioSource audioSource;
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
            else
            {
                yControl = 0;
                xControl = 0;
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
