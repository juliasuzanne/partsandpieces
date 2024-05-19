using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookRequest : MonoBehaviour, ICookable
{
  public string Name { get; set; }
  public string SecondName { get; set; }
  public string ThirdName { get; set; }

  public string Type { get; set; }

  [SerializeField] private string _name;
  [SerializeField] private string _secondName;
  [SerializeField] private string _thirdName;


  [SerializeField] private string _type;
  private CookSuccessManager requestSuccessManager;


  void Start()
  {
    SecondName = _secondName;
    ThirdName = _thirdName;
    Name = _name;
    Type = _type;
    requestSuccessManager = this.transform.parent.parent.GetComponent<CookSuccessManager>();


  }

  public void Match()
  {
    Debug.Log("SUCCESS FROM REQUESTOR");
    requestSuccessManager.Success();
  }

  public void NoMatch()
  {
    Debug.Log("NOT GOOD REQUESTOR");
    requestSuccessManager.NoSuccess();

  }

}
