using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCookRequest : MonoBehaviour, IRequestable
{

  [SerializeField] private GameObject[] dishes;
  [SerializeField] private int requestId;
  [SerializeField] private Transform _targetPos;
  [SerializeField] private GameObject currentDish;
  public GameObject CurrentDish { get; set; }
  private int dishChoice;



  void Start()
  {
    ChooseDish();
  }

  public void ResetChoice()
  {
    Destroy(CurrentDish);
    ChooseDish();
  }

  public void ChooseDish()
  {
    dishChoice = Random.Range(0, dishes.Length);
    CurrentDish = Instantiate(dishes[dishChoice], new Vector3(_targetPos.position.x, _targetPos.position.y, 0f), Quaternion.identity, _targetPos);
    CurrentDish.GetComponent<ICookable>().SetRequestorId(requestId);
  }







}
