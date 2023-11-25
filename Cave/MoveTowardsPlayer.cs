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
    private Vector3 _moveTowardsPos;
    private bool _hitCeiling;
    void Start()
    {
        Destroy(this.gameObject, 17f);
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _target = GameObject.Find("HintTextManager").transform.GetChild(1).transform;
    }
    void Update()
    {
        // Debug.Log(transform.position);
        // Debug.Log(_moveTowardsPos);
        var step = speed * Time.deltaTime; // calculate distance to move
        if (transform.position.y > _target.position.y)
        {
            _hitCeiling = true;
        }
        if (_hitCeiling == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, step);
        }

        else
        {
            _moveTowardsPos = new Vector3(_player.position.x, _player.position.y + Random.Range(0f, 3f), _player.position.z);
            transform.position = Vector3.MoveTowards(transform.position, _moveTowardsPos, step);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject, 2f);
        }
    }
}
