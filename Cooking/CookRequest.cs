using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookRequest : MonoBehaviour, ICookable
{
  public string Name { get; set; }
  public string SecondName { get; set; }
  public string ThirdName { get; set; }
  public int requestId { get; set; }

  public string Type { get; set; }

  [SerializeField] private string _name;
  [SerializeField] private string _secondName;
  [SerializeField] private string _thirdName;
  [SerializeField] private int requestorId;
  private DishController _dishController;



  [SerializeField] private string _type;
  private CookSuccessManager requestSuccessManager;


  void Start()
  {
    SecondName = _secondName;
    ThirdName = _thirdName;
    requestId = requestorId;
    Name = _name;
    Type = _type;
    requestSuccessManager = this.transform.parent.parent.parent.GetComponent<CookSuccessManager>();
    _dishController = FindObjectOfType<DishController>();



  }

  public bool GetEnabled()
  {
    return this.enabled;
  }

  public void SetRequestorId(int newId)
  {
    requestorId = newId;
  }
  public int GetRequestorId()
  {
    return requestorId;
  }

  public void Match(GameObject currentObj)
  {
    if (this.enabled)
    {
      Debug.Log("SUCCESS FROM REQUESTOR");
      requestSuccessManager.Success();
      Destroy(_dishController.GetCurrentItem());
    }

  }

  public void NoMatch()
  {
    if (this.enabled)
    {
      Debug.Log("NOT GOOD REQUESTOR");
      requestSuccessManager.NoSuccess();

    }

  }
}