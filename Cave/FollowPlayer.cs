using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform _player;
    [SerializeField]
    private float _playerOffsetY, _playerOffsetX;


    void Start()
    {
        _player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPos = new Vector2(_player.position.x + _playerOffsetX, _player.position.y + _playerOffsetY);
        transform.position = playerPos;
    }
}
