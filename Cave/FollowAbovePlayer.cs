using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAbovePlayer : MonoBehaviour
{
  private Transform _player;
  [SerializeField]
  private float _playerOffsetY, _playerOffsetX;


  void Start()
  {
    _player = GameObject.Find("AbovePlayer").transform;
  }

  // Update is called once per frame
  void Update()
  {
    Vector3 playerPos = new Vector3(_player.position.x + _playerOffsetX, _player.position.y + _playerOffsetY, _player.position.z);
    transform.position = playerPos;
  }
}
