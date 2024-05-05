using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovementSimple : MonoBehaviour
{
    [SerializeField] private Transform PointA;
    [SerializeField] private Transform PointB;
    [SerializeField] private Animator anim;
    [SerializeField] private float speed;
    [SerializeField] private SpriteRenderer sp;

    private Vector2 targetPos;



    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        targetPos = new Vector2(PointB.position.x, PointB.position.y);
        anim.SetBool("Walking", true);


    }

    void Update()
    {
        if (targetPos.x > transform.position.x)
        {
            sp.flipX = true;
        }
        else
        {
            sp.flipX = false;

        }
        SetTargetPos();

        {
            var step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector2.MoveTowards(transform.position, targetPos, step);
            Debug.Log(targetPos);
        }
    }

    private void SetTargetPos()
    {
        if (transform.position.x == PointA.position.x)
        {
            StartCoroutine("SwitchToPointB");
        }
        else if (transform.position.x == PointB.position.x)
        {
            StartCoroutine("SwitchToPointA");
        }
    }

    private IEnumerator SwitchToPointB()
    {
        yield return new WaitForSeconds(10f);
        targetPos = new Vector2(PointB.position.x, PointB.position.y);
    }

    private IEnumerator SwitchToPointA()
    {
        yield return new WaitForSeconds(10f);
        targetPos = new Vector2(PointA.position.x, PointA.position.y);
    }
}
