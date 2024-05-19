using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class CookObject : MonoBehaviour, IDishable

{
  public string DishName { get; set; }

  [SerializeField] private string dishName;
  [SerializeField] private string dishSecondName;
  [SerializeField] private string dishThirdName;

  private DishController _dishController;

  [SerializeField] private string dishType;
  [SerializeField] private Transform stackPos;
  [SerializeField] private GameObject secondStackedObject;
  public Transform TargetPos { get; set; }

  [SerializeField] private bool stacked = false;
  [SerializeField] private bool secondStacked = false;
  [SerializeField] private GameObject dishObjectToStack;
  private ICookable hit;
  private IDishable targetDish;

  public Transform GetStackPos()
  {
    return TargetPos;
  }



  void Start()
  {
    TargetPos = stackPos;
    DishName = dishName;
    _dishController = FindObjectOfType<DishController>();

  }

  public void ChangeSecondName(string newName)
  {
    dishSecondName = newName;
  }

  public void ChangeThirdName(string thirdName)
  {
    dishThirdName = thirdName;
  }
  void Update()
  {

  }
  public bool Stacked()
  {
    return stacked;
  }

  public bool SecondStacked()
  {
    return secondStacked;
  }

  public void ChangeStacked()
  {
    stacked = true;
  }

  public void ChangeSecondStacked()
  {
    secondStacked = true;
  }

  public void ChangeSecondStackedObject(GameObject newObject)
  {
    secondStackedObject = _dishController.GetCurrentItem();
  }

  public GameObject GetSecondStackedObject()
  {
    return secondStackedObject;
  }



  void OnMouseDown()
  {
    if (_dishController.GetCurrentItem() == null)
    {
      _dishController.ChangeItem(this.gameObject);
    }

    Debug.Log("HIT!" + hit);
    if (hit != null)
    {
      Debug.Log("HIT: " + hit.Name);

      if (hit.Name == dishName && hit.SecondName == dishSecondName && hit.ThirdName == dishThirdName)
      {
        Debug.Log("MATCH");
        hit.Match();
        Destroy(this.gameObject);
      }
      else
      {
        hit.NoMatch();
        Debug.Log("WRONG MATCH");
      }

    }
    else if (targetDish != null)
    {
      if (targetDish.Stacked() == false)
      {
        targetDish.ChangeStacked();
        targetDish.SpawnStack(_dishController.GetCurrentItem());
        targetDish.ChangeSecondName(dishName);
        Destroy(this.gameObject);

      }
      else if (targetDish.SecondStacked() == false)
      {
        targetDish.ChangeSecondStacked();
        targetDish.SpawnThirdStack(_dishController.GetCurrentItem());
        Debug.Log("TRIGGERED OBJ" + targetDish.DishName);
        Debug.Log("DISH NAME" + dishName);
        targetDish.ChangeThirdName(dishName);
        Destroy(this.gameObject);

      }

      else
      {

        Debug.Log("StackFull");
      }
    }
  }

  public void SpawnStack(GameObject prefab)
  {
    secondStackedObject = Instantiate(prefab, new Vector3(stackPos.position.x, stackPos.position.y, 0f), Quaternion.identity, stackPos);
  }

  public void SpawnThirdStack(GameObject prefab)
  {
    Debug.Log("SECONDSTACK TARGET" + secondStackedObject.transform.GetChild(0));
    Instantiate(prefab, new Vector3(secondStackedObject.GetComponent<IDishable>().GetStackPos().position.x, secondStackedObject.GetComponent<IDishable>().GetStackPos().position.y, 0f), Quaternion.identity, secondStackedObject.transform.GetChild(0));
  }


  void OnTriggerEnter2D(Collider2D other)
  {
    hit = other.GetComponent<ICookable>();
    Debug.Log(hit);
    if (_dishController.GetCurrentItem() != null)
    {
      if (_dishController.GetCurrentItem() != other.gameObject && _dishController.GetCurrentItem().GetComponent<IDishable>().Stacked() == false)
      {
        targetDish = other.GetComponent<IDishable>();
      }
    }


  }

  void OnTriggerExit2D(Collider2D other)
  {
    if (other.GetComponent<ICookable>() == hit)
    {
      hit = null;
      Debug.Log("exit");
    }
    if (other.GetComponent<IDishable>() == targetDish)
    {
      targetDish = null;
      Debug.Log("exit trigger");
    }


  }

  public string GetName()
  {
    return dishName;
  }



}

