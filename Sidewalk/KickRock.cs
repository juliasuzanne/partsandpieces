using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickRock : MonoBehaviour
{
    [SerializeField] private float step;
    [SerializeField] private float speed;
    [SerializeField] private Animator animator;
    private Vector2 currentTarget;
    public void Kick(string directionToKick)
    {
        animator.SetTrigger("ClickRock");
        if (directionToKick == "right")
        {
            currentTarget = new Vector2(transform.position.x - step, transform.position.y);
        }
        else if (directionToKick == "left")
        {
            currentTarget = new Vector2(transform.position.x + step, transform.position.y);
        }
        else if (directionToKick == "down")
        {
            currentTarget = new Vector2(transform.position.x, transform.position.y - step);
        }
        else if (directionToKick == "up")
        {
            currentTarget = new Vector2(transform.position.x, transform.position.y + step);
        }
    }

    void Start()
    {
        currentTarget = transform.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);

    }


}
