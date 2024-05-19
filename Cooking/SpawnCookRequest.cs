using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCookRequest : MonoBehaviour
{
  [SerializeField] private GameObject[] dishes;
  [SerializeField] private Transform _targetPos;

  private int dishChoice;



  void Start()
  {
    dishChoice = Random.Range(0, dishes.Length);
    Instantiate(dishes[dishChoice], new Vector3(_targetPos.position.x, _targetPos.position.y, 0f), Quaternion.identity, _targetPos);


  }

}
