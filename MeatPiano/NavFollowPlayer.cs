using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavFollowPlayer : MonoBehaviour
{
    private Vector3 target;
    [SerializeField] private Transform followPlayer;
    NavMeshAgent agent;


    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        SetTargetPosition();
        SetAgentPosition();
    }

    void SetTargetPosition()
    {
        target = new Vector3(followPlayer.position.x, followPlayer.position.y, followPlayer.position.z);
    }

    void SetAgentPosition()
    {
        Debug.Log("target = " + target);
        agent.SetDestination(new Vector3(target.x, target.y, transform.position.z));
    }
}
