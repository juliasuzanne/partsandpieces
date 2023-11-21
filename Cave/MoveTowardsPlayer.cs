using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    private Transform _player;
    [SerializeField]
    private float speed = 4.85f;
    [SerializeField]
    private Transform _target;
    void Start()
    {
        Destroy(this.gameObject, 17f);
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _target = GameObject.Find("HintTextManager").transform.GetChild(1).transform;
    }
    void Update()
    {
        var step = speed * Time.deltaTime; // calculate distance to move
        if (transform.position.y < -6.7f)
            transform.position = Vector3.MoveTowards(transform.position, _target.position, step);
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _player.position, step);
        }
        if (transform.position == _player.position)
        {
            Destroy(this.gameObject);
        }
    }
}
