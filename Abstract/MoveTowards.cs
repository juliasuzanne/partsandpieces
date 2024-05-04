using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{

    [SerializeField] private Transform PointA;
    [SerializeField] private Transform PointB;
    private Vector2 targetPos;
    private bool _idling = false;
    [SerializeField] private float speed;




    // Start is called before the first frame update
    void Start()
    {

        targetPos = PointB.position;
    }

    public void IdlingTrue()
    {
        _idling = true;
    }

    // Update is called once per frame
    void Update()
    {
        SetTargetPos();
        if (_idling == true)
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
            targetPos = new Vector2(PointB.position.x, PointB.position.y);
        }
        else if (transform.position.x == PointB.position.x)
        {
            targetPos = new Vector2(PointA.position.x, PointA.position.y);
        }
    }
}
