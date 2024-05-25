using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform _player;
    [SerializeField] private bool usingZ;
    [SerializeField]
    private float _playerOffsetY, _playerOffsetX, _playerOffsetZ;


    void Start()
    {
        _player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (usingZ == true)
        {
            Vector3 playerPos = new Vector3(_player.position.x + _playerOffsetX, _player.position.y + _playerOffsetY, _player.position.z + _playerOffsetZ);
            transform.position = playerPos;
        }
        else
        {
            Vector2 playerPos = new Vector2(_player.position.x + _playerOffsetX, _player.position.y + _playerOffsetY);
            transform.position = playerPos;
        }

    }
}
